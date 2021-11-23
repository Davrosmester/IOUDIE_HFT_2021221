using IOUDIE_HFT_2021221.Logic;
using IOUDIE_HFT_2021221.Models;
using IOUDIE_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOUDIE_HFT_2021221.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<ICarLogic, CarLogic>(); //IOC Container/Controller
            services.AddTransient<ICarShopRepository, CarRepository>();

            services.AddTransient<IBrandLogic, BrandLogic>();
            services.AddTransient<IBrandRepository, BrandRepository>();

            services.AddTransient<IDriverLogic, DriverLogic>();
            services.AddTransient<IDriversRepository, DriversRepository>();

            services.AddTransient<DbContext, CarDBContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
