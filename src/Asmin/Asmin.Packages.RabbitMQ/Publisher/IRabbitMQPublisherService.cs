using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Packages.RabbitMQ.Publisher
{
    /// <summary>
    /// This interface provides publishing list of data to RabbitMQ queue.
    /// </summary>
    public interface IRabbitMQPublisherService
    {
        /// <summary>
        /// Insert list of object to RabbitMQ queue.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="listOfData">List of T, T must be reference type</param>
        /// <param name="queueName">RabbitMQ queue name</param>
        void Enqueue<T>(IEnumerable<T> listOfData, string queueName) where T : class, new();
    }
}
