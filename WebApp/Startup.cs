using Data.DataContext;
using DomainServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.AppInterfaces;
using Services.DomainInterfaces;
using WebApp.AppConfig;
using WebApp.Common;
using WebApp.Service;

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
            _configuration.Bind("Project", new Config());

            services.AddSingleton<IDataServiceFactory, DataServiceFactory>();
            services.AddSingleton<IServiceItemService, ServiceItemService>();
            services.AddSingleton<ITextFieldService, TextFieldService>();

            services.AddIdentity<IdentityUser, IdentityRole>(x =>
            {
                x.User.RequireUniqueEmail = true;
                x.Password.RequiredLength = 6;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireLowercase = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(x =>
            {
                x.Cookie.Name = "myCompanyAuth";
                x.Cookie.HttpOnly = true;
                x.LoginPath = "/account/login";
                x.AccessDeniedPath = "/account/accessdenied";
                x.SlidingExpiration = true;
            });

            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy =>
                {
                    policy.RequireRole("admin");
                });
            });

            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
