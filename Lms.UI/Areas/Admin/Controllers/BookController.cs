using Lms.BusinessLogic.Abstract;
using Lms.BusinessLogic.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lms.UI.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize(Roles = "Worker")]
    public class BookController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IBookService _bookService;
        public BookController(ICategoryService categoryService,
                              IAuthorService authorService,
                              IWebHostEnvironment webHostEnvironment,
                              IBookService bookService)
        {
            _categoryService = categoryService;
            _authorService = authorService;
            _webHostEnvironment = webHostEnvironment;
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var categoires = await _categoryService.GetCategoriesDictionaryAsync();
            var authors = await _authorService.GetAuthorDictionaryAsync();
            TempData["Categories"] = new SelectList(categoires, "Key", "Value");
            TempData["Authors"] = new SelectList(authors, "Key", "Value");
            AddBookDto addBookDto = new();
            return View(addBookDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookDto bookDto, IList<IFormFile> imagesFile)
        {

            if (imagesFile is not null && imagesFile.Count > 0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

                if (Directory.Exists(uploadsFolder) is false)
                {
                    Directory.CreateDirectory(uploadsFolder);
                }


                foreach (var image in imagesFile)
                {
                    if (image.Length > 0)
                    {
                        string uniqueImageName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(image.FileName);
                        string filePath = Path.Combine(uploadsFolder, uniqueImageName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await image.CopyToAsync(fileStream);
                        }
                        bookDto.UploadedFileDtos.Add(new UploadedFileDto
                        {
                            FileName = uniqueImageName,
                            RelativePath = filePath,
                            ContentType = image.ContentType,
                        }); ;
                    }
                }

                var result = await _bookService.AddAsync(bookDto);

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
            }

            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public async Task<IActionResult> GetBook()
        {
            var result = await _bookService.GetAllAsync();
            return Json(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveBook(int id)
        {
            var result = await _bookService.RemoveAsync(id);
            if (result.ResponseType == CoreLayer.Enums.ResponseType.NotFound)
            {
                return Json(new { success = false, message = result.Message });
            }
            return Json(new { success = true, message = "Book was deleted successfully" });

        }
    }
}
