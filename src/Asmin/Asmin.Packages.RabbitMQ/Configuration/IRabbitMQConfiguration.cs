using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Packages.RabbitMQ.Configuration
{
    /// <summary>
    /// RabbitMQ configuration
    /// </summary>
    public interface IRabbitMQConfiguration
    {
        /// <summary>
        /// RabbitMQ host name
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// RabbitMQ port
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// RabbitMQ username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// RabbitMQ password
        /// </summary>
        public string Password { get; set; }
    }
}
