using SmartLibrary.Models;
using SmartLibrary.Statics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.SameSite = SameSiteMode.Strict;
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseSession();

SmartData.Set("world", new CacheOptions()
{
    RenewalRequestInfo = new RequestModel()
    {
        Url = "https://trends24.in/",

    },
    ExpiryTime = TimeSpan.FromMinutes(10),
});

SmartData.Set("usa", new CacheOptions()
{
    RenewalRequestInfo = new RequestModel()
    {
        Url = "https://trends24.in/united-states/",

    },
    ExpiryTime = TimeSpan.FromMinutes(10),
});

SmartData.Set("uk", new CacheOptions()
{
    RenewalRequestInfo = new RequestModel()
    {
        Url = "https://trends24.in/united-kingdom/",

    },
    ExpiryTime = TimeSpan.FromMinutes(10),
});

SmartData.Set("india", new CacheOptions()
{
    RenewalRequestInfo = new RequestModel()
    {
        Url = "https://trends24.in/india/",

    },
    ExpiryTime = TimeSpan.FromMinutes(10),
});

SmartData.Set("germany", new CacheOptions()
{
    RenewalRequestInfo = new RequestModel()
    {
        Url = "https://trends24.in/germany/",

    },
    ExpiryTime = TimeSpan.FromMinutes(10),
});

SmartData.Set("france", new CacheOptions()
{
    RenewalRequestInfo = new RequestModel()
    {
        Url = "https://trends24.in/france/",

    },
    ExpiryTime = TimeSpan.FromMinutes(10),
});

SmartData.Set("brazil", new CacheOptions()
{
    RenewalRequestInfo = new RequestModel()
    {
        Url = "https://trends24.in/brazil/",

    },
    ExpiryTime = TimeSpan.FromMinutes(10),
});

SmartData.Set("africa", new CacheOptions()
{
    RenewalRequestInfo = new RequestModel()
    {
        Url = "https://trends24.in/south-africa/",

    },
    ExpiryTime = TimeSpan.FromMinutes(10),
});

SmartData.Set("turkey", new CacheOptions()
{
    RenewalRequestInfo = new RequestModel()
    {
        Url = "https://trends24.in/turkey/",

    },
    ExpiryTime = TimeSpan.FromMinutes(10),
});

SmartData.Set("arabia", new CacheOptions()
{
    RenewalRequestInfo = new RequestModel()
    {
        Url = "https://trends24.in/saudi-arabia/",

    },
    ExpiryTime = TimeSpan.FromMinutes(10),
});





app.Run();
