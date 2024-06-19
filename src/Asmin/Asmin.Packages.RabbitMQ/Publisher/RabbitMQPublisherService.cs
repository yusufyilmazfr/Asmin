using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Asmin.Packages.RabbitMQ.Service;
using Newtonsoft.Json;

namespace Asmin.Packages.RabbitMQ.Publisher
{
    public class RabbitMQPublisherService : IRabbitMQPublisherService
    {
        private IRabbitMQService _RabbitMQService;

        public RabbitMQPublisherService(IRabbitMQService rabbitMqService)
        {
            _RabbitMQService = rabbitMqService;
        }

        public void Enqueue<T>(IEnumerable<T> listOfData, string queueName) where T : class, new()
        {
            using var connection = _RabbitMQService.CreateConnection();
            using var channel = _RabbitMQService.CreateModel(connection);

            channel.QueueDeclare(queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            foreach (var data in listOfData)
            {
                var jsonData = JsonConvert.SerializeObject(data);
                var body = Encoding.UTF8.GetBytes(jsonData);

                channel.BasicPublish(exchange: "", routingKey: queueName, mandatory: false, basicProperties: null, body: body);
            }
        }
    }
}
