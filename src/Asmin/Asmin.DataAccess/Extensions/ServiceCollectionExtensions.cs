using System;
using System.Collections.Generic;
using System.Text;
using Asmin.DataAccess.Abstract;
using Asmin.DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace Asmin.DataAccess.Extensions
{
    /// <summary>
    /// ServiceCollectionExtensions contains extended IServiceCollection's methods.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register business module dependencies to IServiceCollection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDataAccessModule(this IServiceCollection services)
        {
            services.AddSingleton<IUserDal, EfUserDal>();
            services.AddSingleton<IIncomingVisitorDal, EfIncomingVisitorDal>();

            return services;
        }
    }
}
