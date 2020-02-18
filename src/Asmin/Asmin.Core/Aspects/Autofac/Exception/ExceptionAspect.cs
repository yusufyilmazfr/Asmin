using Asmin.Core.Utilities.Interceptor;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.Aspects.Autofac.Exception
{
    public class ExceptionAspect : MethodInterception
    {
        public override void OnException(IInvocation invocation, System.Exception e)
        {
            //Todo, this function will be take a log.
        }
    }
}
