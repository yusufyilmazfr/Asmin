using System;
using System.Collections.Generic;
using System.Text;
using Asmin.Packages.RabbitMQ.Configuration;
using RabbitMQ.Client;

namespace Asmin.Packages.RabbitMQ.Service
{
    /// <summary>
    /// RabbitMQService implements IRabbitMQService methods.
    /// </summary>
    public class RabbitMQService : IRabbitMQService
    {
        /// <summary>
        /// RabbitMQ configuration property.
        /// </summary>
        private readonly IRabbitMQConfiguration _rabbitMqConfiguration;

        /// <summary>
        /// Constructor based dependency injection.
        /// </summary>
        /// <param name="rabbitMqConfiguration">IRabbitMQConfiguration instance</param>
        public RabbitMQService(IRabbitMQConfiguration rabbitMqConfiguration)
        {
            _rabbitMqConfiguration = rabbitMqConfiguration;
        }

        public IConnection CreateConnection()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = _rabbitMqConfiguration.Host,
                Port = _rabbitMqConfiguration.Port,
                UserName = _rabbitMqConfiguration.Username,
                Password = _rabbitMqConfiguration.Password
            };

            return connectionFactory.CreateConnection();
        }

        public IModel CreateModel(IConnection connection)
        {
            return connection.CreateModel();
        }
    }
}
