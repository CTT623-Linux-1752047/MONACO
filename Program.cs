using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MONACO_ASP.Data;
using MONACO_ASP.Data.Imp;
using MONACO_ASP.Services.Categories.Imp;
using MONACO_ASP.Services.Categories;
using FluentValidation;
using MONACO_ASP.Models.Auth;
using MONACO_ASP.Validators.Auth;
using MONACO_ASP.Services.Employees.Imp;
using MONACO_ASP.Services.Employees;
using MONACO_ASP.Infracstructures.Digister;
using MONACO_ASP.Infracstructures;
using MONACO_ASP.Services.Authentication;
using MONACO_ASP.Services.Authenticate.Imp;
using MONACO_ASP.Services.Brands;
using MONACO_ASP.Services.Brands.Imp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<ICryptographyHelper, CryptographyHelper>();

// DI 
builder.Services.AddDbContext<AppDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Queryable
builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));

// Add all services instance 
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();
builder.Services.AddScoped<IEmployeeRegistrationService, EmployeeRegistrationService>();

// Add Fulent Valid
builder.Services.AddScoped<IValidator<LoginModel>, LoginValidator>();

// Authenticate 
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).
    AddCookie(option => {
        option.LoginPath = "/Admin/Login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        option.ReturnUrlParameter = "returnUrl";
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.UseEndpoints(endpoints =>
{
    //endpoints.MapRazorPages();

    //Route for login admin 
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Login}/{action=Login}"
		);

	endpoints.MapAreaControllerRoute(
		name: "AdminIndex",
		areaName: "Admin",
		pattern: "Admin/{controller=Home}/{action=Index}"
		);

	endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

	endpoints.MapControllerRoute(
		name: "products",
		pattern: "Products",
		defaults: new { controller = "Products", action = "index" }
	);

	endpoints.MapControllerRoute(
		name: "brands",
		pattern: "Brands",
		defaults: new { controller = "Brands", action = "index" }
	);

	// Default route (keep this at the end)
	endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
