using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Asmin.Core.Configuration.Environment
{
    public class EnvironmentService : IEnvironmentService
    {
        private static IConfiguration _configuration;

        private static string _environmentVariableValue = "";
        private static string _environmentVariableKey = "ASMIN_ENVIRONMENT";

        public EnvironmentService()
        {
            SetEnvironmentValue();
            SetConfiguration();
        }

        public IConfiguration Configuration => _configuration;

        private void SetConfiguration()
        {
            if (_configuration == null)
            {
                var configurationBuilder = new ConfigurationBuilder();

                var appsettingsFileName = $"appsettings.{_environmentVariableValue.ToLower()}.json";

                _configuration = configurationBuilder.SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile(appsettingsFileName, optional: false, reloadOnChange: true)
                    .Build();
            }
        }

        private void SetEnvironmentValue()
        {
            if (Debugger.IsAttached)
            {
                _environmentVariableValue = System.Environment.GetEnvironmentVariable(_environmentVariableKey);
            }
            else
            {
                _environmentVariableValue = System.Environment.GetEnvironmentVariable(_environmentVariableKey, EnvironmentVariableTarget.Process);
            }

            if (_environmentVariableValue == null)
            {
                throw new ArgumentException($"{_environmentVariableKey} environment can not be null!");
            }
        }

        public bool IsDevelopment => _environmentVariableValue.ToLower() == "development";
        public bool IsStaging => _environmentVariableValue.ToLower() == "staging";
        public bool IsTest => _environmentVariableValue.ToLower() == "test";
        public bool IsProduction => _environmentVariableValue.ToLower() == "production";
    }
}
