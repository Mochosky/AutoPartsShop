using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoPartsShop.Interfaces;
using AutoPartsShop.Repositories;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AutoPartsShop
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<ICategory, CategoryRepository>();
            services.AddScoped<IPart, PartRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // TODO: Jaime, remember to disable this prior to go live!;
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // TODO: Deletes the default map comming in the application and add a custom map pattern.
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});

                // Use this route options to route the application to the initial page desired.
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Part}/{action=List}/{Id?}"
                    );
            });
        }
    }
}