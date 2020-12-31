using System;
using System.Collections.Generic;
using System.Text;
using Asmin.Packages.RabbitMQ.Configuration;
using Asmin.Packages.RabbitMQ.Publisher;
using Asmin.Packages.RabbitMQ.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Asmin.Packages.RabbitMQ.Extensions
{
    /// <summary>
    /// ServiceCollectionExtensions contains extended IServiceCollection's methods.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Extension method for IServiceCollection
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services, RabbitMQConfiguration configuration)
        {
            services.AddSingleton(typeof(IRabbitMQConfiguration), configuration);

            services.AddSingleton<IRabbitMQService, RabbitMQService>();

            services.AddSingleton<IRabbitMQPublisherService, RabbitMQPublisherService>();

            return services;
        }
    }
}
