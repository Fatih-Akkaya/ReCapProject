using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ICarDAL, EFCarDAL>();
            services.AddSingleton<ICarService,CarManager>();
            services.AddSingleton<IBrandDAL, EFBrandDAL>();
            services.AddSingleton<IBrandService, BrandManager>();
            services.AddSingleton<IColorDAL, EFColorDAL>();
            services.AddSingleton<IColorService, ColorManager>();
            services.AddSingleton<ICustomerDAL, EFCustomerDAL>();
            services.AddSingleton<ICustomerService, CustomerManager>();
            services.AddSingleton<IRentalDAL, EFRentalDAL>();
            services.AddSingleton<IRentalService, RentalManager>();
            services.AddSingleton<IUserDAL, EFUserDAL>();
            services.AddSingleton<IUserService, UserManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
