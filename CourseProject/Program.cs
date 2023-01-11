using CourseProject.Areas.Identity.Data;
using CourseProject.Data;
using CourseProject.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<AddFieldToUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireDigit = false;
    
    options.User.RequireUniqueEmail = true;
});

builder.Services.Configure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, options =>
{
    options.LoginPath = "/Identity/User/Login";
    options.AccessDeniedPath = "/Identity/User/AccessDenied";
});

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
SeedData.SeedDatabase(context);

app.MapControllers();

app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=User}/{action=Index}/{id?}"
);

app.MapDefaultControllerRoute();

app.MapRazorPages();

app.UseAuthentication();

app.UseAuthorization();

app.UseStaticFiles();
app.Run();
