using Asmin.Business.Abstract;
using Asmin.Business.Concrete;
using Asmin.Business.ValidationRules.FluentValidation;
using Asmin.Core.Entities.Concrete;
using Asmin.Core.Utilities.Interceptor;
using Asmin.DataAccess.Abstract;
using Asmin.DataAccess.Concrete.EntityFramework;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Asmin.Business.DependencyModules.Autofac
{
    public class AutofacDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Data Access Dependency Registration

            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<EfIncomingVisitorDal>().As<IIncomingVisitorDal>().SingleInstance();

            #endregion

            #region Business Dependency Registration

            builder.RegisterType<UserManager>().As<IUserManager>();
            builder.RegisterType<IncomingVisitorManager>().As<IIncomingVisitorManager>().SingleInstance();
            builder.RegisterType<UserValidator>().As<IValidator<User>>();

            #endregion

            #region Register Assembly

            var executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(executingAssembly)
                 .Where(type => !type.Name.EndsWith("Validator"))
                 .AsImplementedInterfaces()
                 .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                 {
                     Selector = new AspectInterceptorSelector()
                 })
                 .SingleInstance();

            #endregion
        }
    }
}
