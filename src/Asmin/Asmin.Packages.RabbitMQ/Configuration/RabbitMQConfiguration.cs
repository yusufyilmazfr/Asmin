using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Packages.RabbitMQ.Configuration
{
    /// <summary>
    /// RabbitMQ configuration
    /// </summary>
    public class RabbitMQConfiguration : IRabbitMQConfiguration
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
