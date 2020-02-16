using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class FileLogger : LoggerServiceBase
    {
        private static string LOGGER_NAME = "JsonFileLogger";
        public FileLogger() : base(LOGGER_NAME)
        {
        }
    }
}
