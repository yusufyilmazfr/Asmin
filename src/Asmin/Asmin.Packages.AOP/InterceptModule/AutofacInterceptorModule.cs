using System;
using System.Collections.Generic;
using System.Text;
using Asmin.Packages.AOP.Interceptor;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace Asmin.Packages.AOP.InterceptModule
{
    public class AutofacInterceptorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(executingAssembly)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                })
                .SingleInstance();
        }
    }
}
