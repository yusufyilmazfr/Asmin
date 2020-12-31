using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Asmin.Core.Configuration.Environment
{
    /// <summary>
    /// Environment service interface. This service provides IConfiguration instance and environment flags.
    /// </summary>
    public interface IEnvironmentService
    {
        /// <summary>
        /// This method returns IConfiguration instance.
        /// </summary>
        /// <returns></returns>
        IConfiguration Configuration { get; }

        /// <summary>
        /// Check project mode is development.
        /// </summary>
        bool IsDevelopment { get; }
        /// <summary>
        /// Check project mode is staging.
        /// </summary>
        bool IsStaging { get; }
        /// <summary>
        /// Check project mode is test.
        /// </summary>
        bool IsTest { get; }
        /// <summary>
        /// Check project mode is production.
        /// </summary>
        bool IsProduction { get; }
    }
}
