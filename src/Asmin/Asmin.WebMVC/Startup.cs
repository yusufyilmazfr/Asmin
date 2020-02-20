using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asmin.Business.DependencyModules.Autofac;
using Asmin.Core.DependencyModules;
using Asmin.Core.Extensions;
using Asmin.WebMVC.Services.Session;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Asmin.WebMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Add any Autofac modules or registrations.
            // This is called AFTER ConfigureServices so things you
            // register here OVERRIDE things registered in ConfigureServices.
            //
            // You must have the call to `UseServiceProviderFactory(new AutofacServiceProviderFactory())`
            // when building the host or this won't be called.
            builder.RegisterModule(new AutofacDependencyModule());
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddDistributedMemoryCache();

            services.AddSession();

            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddControllersWithViews();

            services.AddDependencyModules(new ICoreModule[]
            {
                new MemoryCacheModule(),
                new MD5HashModule()
            });

            services.AddSingleton<ISessionService, SessionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMVCExceptionMiddleware("i will be write error page url. :)");


            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "Admin",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
