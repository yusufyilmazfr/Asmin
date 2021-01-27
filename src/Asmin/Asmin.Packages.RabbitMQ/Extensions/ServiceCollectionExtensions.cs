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
        /// Register in RabbitMQ dependencies to IServiceCollection
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services, Action<IRabbitMQConfiguration> configuration)
        {
            IRabbitMQConfiguration rabbitMqConfiguration = new RabbitMQConfiguration();
            configuration.Invoke(rabbitMqConfiguration);

            services.AddSingleton<IRabbitMQConfiguration>(rabbitMqConfiguration);

            services.AddSingleton<IRabbitMQService, RabbitMQService>();

            services.AddSingleton<IRabbitMQPublisherService, RabbitMQPublisherService>();

            return services;
        }
    }
}
