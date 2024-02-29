using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using MVCAssign1;
using MVCAssign1.Models;
using MVCAssign1.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });

builder.Services.AddDbContext<CarContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("PrimaryConnString")));

//ZBOG IDENTITY FRAMEWORK-A
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<CarContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
//ZBOG IDENTITY FRAMEWORK-A-finish

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

// D.I. 

builder.Services.AddScoped<ICarRepository,CarRepository>();

// D.I-finsih





var app = builder.Build();


var supportedCultures = new[] { "en", "de-DE", "sr" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
                          .AddSupportedCultures(supportedCultures)
                          .AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);  //aktiviranje midlwear-a


if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
     // await DataStart.SeedUsersAndRolesAsync(app);
}

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

app.UseAuthentication();//dodao 

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Car}/{action=Index}/{id?}");

app.Run();
