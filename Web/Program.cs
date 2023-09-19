using DataAccess.Data;
using DataAccess.Repository;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Utility;
using Stripe;
using DataAccess.DbInitializer;
using Models;
using SendGrid.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Add services to the container.
builder.Services.AddControllersWithViews().AddViewLocalization
(LanguageViewLocationExpanderFormat.SubFolder)
.AddDataAnnotationsLocalization();

builder.Services.Configure<RequestLocalizationOptions>(options => {
    var supportedCultures = new[] { "en-US", "uk" };
    options.SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultUI()
        .AddDefaultTokenProviders();

// добавляємо після виклику AddIdentity
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});


builder.Services.AddAuthentication()
    .AddFacebook(options =>
    {
        options.AppId = "";
        options.AppSecret = "";
    });



builder.Services.AddAuthentication()
    .AddMicrosoftAccount(options =>
    {
        options.ClientId = "";
        options.ClientSecret = "";
    });


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddRazorPages();

//SendGrid
builder.Services.Configure<SendGridSettings>(builder.Configuration.GetSection("SendGridSettings"));

builder.Services.AddSendGrid(options =>
{
    options.ApiKey = builder.Configuration.GetSection("SendGridSettings")
    .GetValue<string>("ApiKey");
});

builder.Services.AddScoped<IEmailSender, EmailSender>();

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

app.UseStatusCodePagesWithRedirects("/errors/{0}");


StripeConfiguration.ApiKey = builder.Configuration
                .GetSection("StripeSettings").GetValue<string>("SecretKey");

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
SeedDatabase();

app.MapRazorPages();


// 4. defining Cultures
var supportedCultures = new[] { "en-US", "uk" };
// 5. The Middleware settings that will accept the
// Culture from the HttpRequest
var localizationOptions = new RequestLocalizationOptions()
.SetDefaultCulture(supportedCultures[0])
.AddSupportedCultures(supportedCultures)
.AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);



app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();



void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }

}