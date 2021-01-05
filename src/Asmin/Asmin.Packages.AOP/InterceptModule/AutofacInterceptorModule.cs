using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Asmin.Packages.AOP.Interceptor;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Module = Autofac.Module;

namespace Asmin.Packages.AOP.InterceptModule
{
    public class AutofacInterceptorModule : Module
    {
        private Assembly _assembly;

        public void Load(Assembly assembly)
        {
            _assembly = assembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(_assembly)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                })
                .SingleInstance();
        }
    }
}
