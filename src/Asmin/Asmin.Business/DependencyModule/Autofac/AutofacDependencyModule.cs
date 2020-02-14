using Asmin.Business.Abstract;
using Asmin.Business.Concrete;
using Asmin.DataAccess.Abstract;
using Asmin.DataAccess.Concrete.EntityFramework;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Business.DependencyModule.Autofac
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

            #endregion
        }
    }
}
