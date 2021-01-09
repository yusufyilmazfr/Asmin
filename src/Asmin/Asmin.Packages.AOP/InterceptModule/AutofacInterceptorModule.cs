using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Asmin.Packages.AOP.Attributes;
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
                .Where(type =>
                {
                    var checkHasIgnoreAttribute = type.GetCustomAttributes(false).Any(attribute => attribute.GetType().Name == nameof(IgnoreAOPPackageAttribute));

                    return !checkHasIgnoreAttribute;
                })
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                })
                .SingleInstance();
        }
    }
}
