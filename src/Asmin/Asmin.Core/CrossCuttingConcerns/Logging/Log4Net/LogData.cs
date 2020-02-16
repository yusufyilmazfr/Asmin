using log4net.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LogData
    {
        private LoggingEvent _loggingEvent;

        public LogData(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        public object Message => _loggingEvent.MessageObject;
    }
}
