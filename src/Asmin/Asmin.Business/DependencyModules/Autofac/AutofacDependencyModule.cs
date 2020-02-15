using Asmin.Business.Abstract;
using Asmin.Business.Concrete;
using Asmin.Business.ValidationRules.FluentValidation;
using Asmin.Core.Utilities.Interceptor;
using Asmin.DataAccess.Abstract;
using Asmin.DataAccess.Concrete.EntityFramework;
using Asmin.Entities.Concrete;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Business.DependencyModules.Autofac
{
    public class AutofacDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Data Access Dependency Registration

            builder.RegisterType<EfUserDal>().As<IUserDal>();

            #endregion

            #region Business Dependency Registration

            builder.RegisterType<UserManager>().As<IUserManager>();
            builder.RegisterType<UserValidator>().As<IValidator<User>>();

            #endregion

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
