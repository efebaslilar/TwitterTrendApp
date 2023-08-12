using TwitterTrends;

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

app.MapFallbackToController("Index", "Home");

app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 404||context.Response.StatusCode==500)
    {
        context.Request.Path = "/Home/Index";
        await next();
    }
    
});

Timer timer = new Timer(GetTrendhtml, null, TimeSpan.Zero, TimeSpan.FromMinutes(30));
Timer timerr = new Timer(GetSync, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
app.Run();

void GetTrendhtml(object state)
{
    app.PrepareData();
}

void GetSync(object state)
{
    app.SyncData();
}