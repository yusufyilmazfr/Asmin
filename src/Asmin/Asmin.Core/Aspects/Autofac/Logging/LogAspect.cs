using Asmin.Core.Constants.Messages;
using Asmin.Core.CrossCuttingConcerns.Logging;
using Asmin.Core.CrossCuttingConcerns.Logging.Log4Net;
using Asmin.Core.Utilities.Exceptions;
using Asmin.Core.Utilities.Interceptor;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;

        public LogAspect(Type loggerServiceType)
        {
            if (loggerServiceType.BaseType != typeof(LoggerServiceBase))
            {
                throw new AspectException(AspectMessages.WrongLoggerType);
            }

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerServiceType);
        }

        public override void OnBefore(IInvocation invocation)
        {
            var logDetail = GetLogDetail(invocation);
            _loggerServiceBase.Info(logDetail);
        }

        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();

            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                var logParameter = new LogParameter
                {
                    Type = invocation.Arguments[i].GetType().Name,
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i]
                };

                logParameters.Add(logParameter);
            }

            var logDetail = new LogDetail
            {
                LogParameters = logParameters,
                MethodName = $"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}"
            };

            return logDetail;
        }
    }
}
