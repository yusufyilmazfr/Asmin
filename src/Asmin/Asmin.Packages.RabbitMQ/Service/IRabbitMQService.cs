using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace Asmin.Packages.RabbitMQ.Service
{
    /// <summary>
    /// RabbitMQ service interface provides you have to IConnection and IModel instance.
    /// </summary>
    public interface IRabbitMQService
    {
        /// <summary>
        /// Create IConnection instance.
        /// </summary>
        /// <returns></returns>
        IConnection CreateConnection();
        /// <summary>
        /// Create IModel instance from specified IConnection instance.
        /// </summary>
        /// <param name="connection">IConnection instance</param>
        /// <returns></returns>
        IModel CreateModel(IConnection connection);
    }
}
