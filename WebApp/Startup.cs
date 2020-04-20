using DomainServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddSingleton<IUserService, UserService>();

            services.ConfigureApplicationCookie(x =>
            {
                x.Cookie.Name = "myCompanyAuth";
                x.Cookie.HttpOnly = true;
                x.LoginPath = "/account/login";
                x.AccessDeniedPath = "/account/accessdenied";
                x.SlidingExpiration = true;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });


            //services.AddAuthorization(x =>
            //{
            //    x.AddPolicy("AdminArea", policy =>
            //    {
            //        policy.RequireRole("admin");
            //    });
            //});

            //services.AddControllersWithViews(x =>
            //{
            //    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            //})
            services.AddControllersWithViews().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
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
