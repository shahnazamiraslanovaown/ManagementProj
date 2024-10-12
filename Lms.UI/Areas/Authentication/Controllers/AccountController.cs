using Lms.BusinessLogic.Abstract;
using Lms.BusinessLogic.Dtos;
using Lms.CoreLayer.Helpers;
using Lms.ExternalServicesLayer.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lms.UI.Areas.Authentication.Controllers
{
    [Area("Authentication")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public AccountController(IUserService userService,
                                 IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }

        public async Task<IActionResult> Register()
        {
            CreatUserDto userDto = new();
            return View(userDto);
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreatUserDto userDto)
        {
            var result = await _userService.CreateUser(userDto);

            if (result.ResponseType == CoreLayer.Enums.ResponseType.ValidationError)
            {
                foreach (var item in result.ResponseValidationResults)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                return Json(new { success = false, errors });
            }
            string url = $"http://localhost:5226/authentication/account/ConfirmEmail?code={result.Data.ConfirmCode}&userId={result.Data.Id}";
            var htmlMessage = HtmlTemplateGenerator.ConfirmMessage("Click button for complete email verification", url);
            await _emailService.SendEmailAsync(result.Data.Email, "Confirm password", htmlMessage);

            return View();
        }


        [HttpGet]

        public IActionResult EmailConfirmationPage()
        {
            return View();
        }


        [HttpGet]

        public async Task<IActionResult> ConfirmEmail(int code, int userId)
        {
            var result = await _userService.CheckConfirmCodeAsync(code, userId);
            if (result.Data)
            {
                await _userService.ChangeUserStatusAsync(CoreLayer.Enums.RegisterStatusEnum.Active, userId);
                return Redirect("/Authentication/Account/EmailConfirmationPage");

            }
            return Redirect("/Authentication/Account/Register");

        }

        [HttpGet]

        public IActionResult SignIn()
        {
            return View(new SigninUserDto());
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SigninUserDto userDto)
        {

            var result = await _userService.CheckUserAsync(userDto);

            if (result.ResponseType == CoreLayer.Enums.ResponseType.ValidationError)
            {
                foreach (var item in result.ResponseValidationResults)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                return Json(new { success = false, errors });
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()),
                new Claim(ClaimTypes.Name, result.Data.FirstName),
                new Claim(ClaimTypes.Surname, result.Data.LastName),
                new Claim(ClaimTypes.Role, "Worker"),
            };

            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties()
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
            };

            try
            {
                await HttpContext
              .SignInAsync(
              CookieAuthenticationDefaults.AuthenticationScheme,
              new ClaimsPrincipal(claimsIdentity),
              authProperties);

            }
            catch (Exception e)
            {
                var x = e;
                throw;
            }

            return Json(new { success = true });
        }
    }
}
