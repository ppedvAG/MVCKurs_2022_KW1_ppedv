using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieStoreSample.Data;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using MovieStoreSample.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MovieStoreSampleContext>(options => //AddDBContext wird intern und dem Lifecycle 'Scope' verwendet
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieStoreSampleContext"))); //Provider LocalDB oder Microsoft SQL Server


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MovieStoreIdentityContext>();

builder.Services.AddDbContext<MovieStoreIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieStoreIdentityContextConnection")));

builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    CultureInfo[] supportedCultures = new[]
    {
                    new CultureInfo("en"),
                    new CultureInfo("de"),
                    new CultureInfo("fr")
    };

    options.DefaultRequestCulture = new RequestCulture("de");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
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
app.UseRequestLocalization(app.Services.GetService<IOptions<RequestLocalizationOptions>>().Value);


app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
AppDomain.CurrentDomain.SetData("BildVerzeichnis", app.Environment.WebRootPath);


#region Hier können wir unsere Middlewares platzieren
#endregion

app.MapControllerRoute( name: "movie", pattern: "movie/{*movie}", defaults: new { controller = "Movie", action = "Index" });

app.MapWhen(context => context.Request.Path.ToString().Contains("imagegen"), subapp =>
{
    subapp.UseThumbnailGen();
});

//https://localhost/{controllername}/{action-methode}/id?
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
