using Data.Domain.DataContext;
using DomainServices.Common;
using DomainServices.EFDomainServices;
using DomainServices.ServiceInterfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Common;
using Services.DomainInterfaces;
using Services.DomainServices;

namespace WebApp
{
    public class Startup
    {
        public readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient<IManufacturerRepository, EFManufacturerRepository>();
            services.AddTransient<ICountryRepository, EFCountryRepository>();
            services.AddTransient<IModelRepository, EFModelRepository>();
            services.AddTransient<IDataManager, DataManager>();
            services.AddTransient<IManufacturerService, ManufacturerService>();
            services.AddTransient<IPhoneService, PhoneService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IServiceManager, ServiceManager>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern:"{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
