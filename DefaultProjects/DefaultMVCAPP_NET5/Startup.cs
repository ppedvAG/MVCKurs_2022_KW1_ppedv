using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefaultMVCAPP_NET5
{
    public class Startup
    {
        public Startup(IConfiguration configuration) //IConfiguration repräsentieren aktuell im Default die AppSetting.json + weitere
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Was passiert hier?
            // 1. Hinzufügen und Konfigurieren von Komponenten 


            services.AddControllersWithViews(); //MVC 
            //services.AddControllers(); //WebAPI - APP 
            //services.AddRazorPages(); //Razor Pages  

            //services.AddMvc(); //AddControllersWithViews + AddRazorPages (beide können nebeneinander verwendet werden)

            
            //Weitere Libraries pder Services z.b IDateService / DateService
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //Für produktive Instanz
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Allgemeine zu verwendete Features 
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //MVC
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                ////WebAPI 
                //endpoints.MapControllers(); 

                ////Razor Pages
                //endpoints.MapRazorPages();
                
            });
        }
    }
}
