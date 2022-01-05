using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieStoreSample.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MovieStoreSampleContext>(options => //AddDBContext wird intern und dem Lifecycle 'Scope' verwendet
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieStoreSampleContext"))); //Provider LocalDB oder Microsoft SQL Server

builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.UseSession();
AppDomain.CurrentDomain.SetData("BildVerzeichnis", app.Environment.WebRootPath);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
