

using DefaultMVCAPP_NET6.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("GameSettings.json",
                        optional: true,
                        reloadOnChange: true);
});



builder.Services.Configure<GameSettings>(builder.Configuration.GetSection("GameSettings"));


// Add services to the container.
builder.Services.AddControllersWithViews(); //Vergleich zu .NET 5 bis Build() kann man diesen Part als ConfigureServices sehen
//weitere Dienste/Klasssen/eigenkaufte Libraries kann man hier mit AddXYZ hinzufügen
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

app.Run();
