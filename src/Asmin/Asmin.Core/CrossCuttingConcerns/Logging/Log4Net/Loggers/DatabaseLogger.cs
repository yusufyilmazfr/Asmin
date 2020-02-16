using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    class DatabaseLogger : LoggerServiceBase
    {
        private static string LOGGER_NAME = "DatabaseLogger";

        public DatabaseLogger() : base(LOGGER_NAME)
        {

        }
    }
}
