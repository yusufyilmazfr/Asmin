using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asmin.Business.Extensions;
using Asmin.Core.Configuration.Context;
using Asmin.Core.Configuration.Environment;
using Asmin.Core.DependencyModules;
using Asmin.Core.Extensions;
using Asmin.Packages.AOP.InterceptModule;
using Asmin.Packages.Hashing.MD5.Extensions;
using Asmin.Packages.JWT.Entities;
using Asmin.Packages.JWT.Extensions;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Asmin.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AsminConfigurationContext = new AsminConfigurationContext(new EnvironmentService());
        }

        public IConfiguration Configuration { get; }
        private IAsminConfigurationContext AsminConfigurationContext { get; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Add any Autofac modules or registrations.
            // This is called AFTER ConfigureServices so things you
            // register here OVERRIDE things registered in ConfigureServices.
            //
            // You must have the call to `UseServiceProviderFactory(new AutofacServiceProviderFactory())`
            // when building the host or this won't be called.

            var executingAssembly = System.Reflection.Assembly.LoadFrom("..\\Asmin.Business\\bin\\Debug\\netcoreapp3.1\\Asmin.Business.dll");
            var interceptorModule = new AutofacInterceptorModule();

            interceptorModule.Load(executingAssembly);

            builder.RegisterModule(interceptorModule);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers();

            services.AddSwaggerGen();

            // Register core module. 🎉
            services.AddCoreModule();

            // Register business module. 🎉
            services.AddBusinessModule();

            // Register MD5 module. 🎉
            services.AddMD5();

            // Register JWT module. 🎉
            services.AddJWT(configuration =>
            {
                configuration.SecretKey = AsminConfigurationContext.JWTKey;
                configuration.Issuer = AsminConfigurationContext.JWTIssuer;
                configuration.Audience = AsminConfigurationContext.JWTAudience;
                configuration.ExpiryHour = AsminConfigurationContext.JWTExpiryHour;
                configuration.TokenSecurityAlgorithms = EnumTokenSecurityAlgorithms.HmacSha256;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Asmin .NET Core Boilerplate API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAPIExceptionMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
