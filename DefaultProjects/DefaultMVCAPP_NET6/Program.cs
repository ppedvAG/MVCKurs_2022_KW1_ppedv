

//using DefaultMVCAPP_NET6.Models;

//var builder = WebApplication.CreateBuilder(args);

//#region PostConfigure -> //Default-Werte und diese können überschrieben werden via normaler Konfigurations-Einlesen
//builder.Services.PostConfigure<PositionOptions>(myOptions =>
//{
//    myOptions.Name = "Max";
//    myOptions.TiTle = "Moritz";
//});

//#endregion


//IConfigurationSection positionSection = builder.Configuration.GetSection(PositionOptions.Position);
//builder.Services.Configure<PositionOptions>(positionSection);





//// Add services to the container.
//builder.Services.AddControllersWithViews(); //Vergleich zu .NET 5 bis Build() kann man diesen Part als ConfigureServices sehen
////weitere Dienste/Klasssen/eigenkaufte Libraries kann man hier mit AddXYZ hinzufügen
//var app = builder.Build();


//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();
