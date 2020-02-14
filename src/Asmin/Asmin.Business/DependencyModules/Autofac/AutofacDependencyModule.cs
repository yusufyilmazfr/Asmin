using Asmin.Business.Abstract;
using Asmin.Business.Concrete;
using Asmin.Business.ValidationRules.FluentValidation;
using Asmin.DataAccess.Abstract;
using Asmin.DataAccess.Concrete.EntityFramework;
using Asmin.Entities.Concrete;
using Autofac;
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
        }
    }
}
