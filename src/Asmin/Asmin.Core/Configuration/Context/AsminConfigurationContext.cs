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

        public AsminConfigurationContext(IEnvironmentService environmentService)
        {
            RedisHost = environmentService.Configuration["Redis:Host"];
            RedisPort = int.Parse(environmentService.Configuration["Redis:Port"]);
            RedisUsername = environmentService.Configuration["Redis:Username"];
            RedisPassword = environmentService.Configuration["Redis:Password"];
        }

    }
}
