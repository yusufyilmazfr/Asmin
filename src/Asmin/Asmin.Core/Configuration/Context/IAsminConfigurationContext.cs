using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.Configuration.Context
{
    /// <summary>
    /// This interface provides value of configuration properties.
    /// </summary>
    public interface IAsminConfigurationContext
    {
        string RedisHost { get; set; }
        int RedisPort { get; set; }
        string RedisUsername { get; set; }
        string RedisPassword { get; set; }

        string RabbitMQHost { get; set; }
        int RabbitMQPort { get; set; }
        string RabbitMQUsername { get; set; }
        string RabbitMQPassword { get; set; }

        string MinIOEndPoint { get; set; }
        string MinIOAccessKey { get; set; }
        string MinIOSecretKey { get; set; }

        string ConnectionString { get; set; }

        string JWTKey { get; set; }
        string JWTIssuer { get; set; }
        string JWTAudience { get; set; }
        int JWTExpiryHour { get; set; }
    }
}
