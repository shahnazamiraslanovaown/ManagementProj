using FluentValidation;
using Lms.BusinessLogic;
using Lms.BusinessLogic.Abstract;
using Lms.BusinessLogic.Concrete;
using Lms.BusinessLogic.Dtos;
using Lms.BusinessLogic.Validations;
using Lms.DataAccessLayer.Abstract;
using Lms.DataAccessLayer.EntityFrameworkCores.Concrete;
using Lms.DataAccessLayer.EntityFrameworkCores.Contexts;
using Lms.Entity.Books;
using Lms.ExternalServicesLayer.Interfaces;
using Lms.ExternalServicesLayer.Models;
using Lms.ExternalServicesLayer.Services;
using Lms.UI.Middlewares;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("local")!;
builder.Services
    .AddDbContext<LmsContext>(options => options.UseSqlServer(connectionString));

var emailConfigurations = builder.Configuration.GetSection("SmtpSetting")!;
builder.Services.Configure<SmtpSetting>(emailConfigurations);

builder.Services.AddTransient<IEmailService, EmailService>();


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserDetailRepository, UserDetailRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IValidator<CreatUserDto>, CreateUserDtoValidator>();
builder.Services.AddScoped<IValidator<SigninUserDto>, SigninUserDtoValidator>();
builder.Services.AddScoped<IValidator<AddBookDto>, AddBookDtoValidator>();

builder.Services.AddAutoMapper(typeof(IServiceRegistration));

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/authentication/account/signin";
        options.AccessDeniedPath = "/authentication/account/signin";
        options.SlidingExpiration = true;
    });


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseDeveloperExceptionPage();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<AuthenticationHandlerMiddleware>();


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Account}/{action=Register}/{id?}"
);

app.MapControllerRoute(
    name: "areas",
    pattern: "{area}/{controller=Book}/{action=Index}/{id?}"
);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();