using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Asmin.Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LoggerServiceBase
    {
        private string LOG_CONFIG_FILE_NAME = "log4net.config";

        private ILog _log;

        public LoggerServiceBase(string name)
        {
            XmlDocument log4NetConfig = new XmlDocument();

            log4NetConfig.Load(File.OpenRead(LOG_CONFIG_FILE_NAME));

            var loggerRepository = LogManager
                .CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(loggerRepository, log4NetConfig["log4net"]);

            _log = LogManager.GetLogger(loggerRepository.Name, name);
        }

        public bool IsInfoEnabled => _log.IsInfoEnabled;
        public bool IsDebugEnabled => _log.IsDebugEnabled;
        public bool IsErrorEnabled => _log.IsErrorEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;

        public void Warn(object message)
        {
            if (IsWarnEnabled)
            {
                _log.Warn(message);
            }
        }

        public void Info(object message)
        {
            if (IsInfoEnabled)
            {
                _log.Info(message);
            }
        }
        public void Debug(object message)
        {
            if (IsDebugEnabled)
            {
                _log.Debug(message);
            }
        }
        public void Error(object message)
        {
            if (IsErrorEnabled)
            {
                _log.Error(message);
            }
        }
        public void Fatal(object message)
        {
            if (IsFatalEnabled)
            {
                _log.Fatal(message);
            }
        }
    }
}
