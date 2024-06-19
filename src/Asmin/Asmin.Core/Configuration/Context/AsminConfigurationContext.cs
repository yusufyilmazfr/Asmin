using System;
using System.Collections.Generic;
using System.Text;
using Asmin.Core.Configuration.Environment;

namespace Asmin.Core.Configuration.Context
{
    public class AsminConfigurationContext : IAsminConfigurationContext
    {
        public string RedisHost { get; set; }
        public int RedisPort { get; set; }
        public string RedisUsername { get; set; }
        public string RedisPassword { get; set; }


        public string RabbitMQHost { get; set; }
        public int RabbitMQPort { get; set; }
        public string RabbitMQUsername { get; set; }
        public string RabbitMQPassword { get; set; }

        public string MinIOEndPoint { get; set; }
        public string MinIOAccessKey { get; set; }
        public string MinIOSecretKey { get; set; }

        public string ConnectionString { get; set; }

        public string JWTKey { get; set; }
        public string JWTIssuer { get; set; }
        public string JWTAudience { get; set; }
        public int JWTExpiryHour { get; set; }

        public string ApiUrl { get; set; }

        public AsminConfigurationContext(IEnvironmentService environmentService)
        {
            RedisHost = environmentService.Configuration["Redis:Host"];
            RedisPort = int.Parse(environmentService.Configuration["Redis:Port"]);
            RedisUsername = environmentService.Configuration["Redis:Username"];
            RedisPassword = environmentService.Configuration["Redis:Password"];

            RabbitMQHost = environmentService.Configuration["RabbitMQ:Host"];
            RabbitMQPort = int.Parse(environmentService.Configuration["RabbitMQ:Port"]);
            RabbitMQUsername = environmentService.Configuration["RabbitMQ:Username"];
            RabbitMQPassword = environmentService.Configuration["RabbitMQ:Password"];

            MinIOEndPoint = environmentService.Configuration["MinIO:EndPoint"];
            MinIOAccessKey = environmentService.Configuration["MinIO:AccessKey"];
            MinIOSecretKey = environmentService.Configuration["MinIO:SecretKey"];

            ConnectionString = environmentService.Configuration["ConnectionStrings:ConnectionString"];

            JWTKey = environmentService.Configuration["JWT:Key"];
            JWTIssuer = environmentService.Configuration["JWT:Issuer"];
            JWTAudience = environmentService.Configuration["JWT:Audience"];
            JWTExpiryHour = int.Parse(environmentService.Configuration["JWT:ExpiryHour"]);

            ApiUrl = environmentService.Configuration["ApiUrl"];
        }
    }
}
