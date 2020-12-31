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
    }
}
