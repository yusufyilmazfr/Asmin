using System;
using System.Collections.Generic;
using System.Text;
using Asmin.Packages.AOP.Interceptor;
using Castle.DynamicProxy;

namespace Asmin.Packages.AOP.Aspects.Exception
{
    /// <summary>
    /// AsminExceptionAspect works when method is throwing exception
    /// </summary>
    public class AsminExceptionAspect : MethodInterceptor
    {
        public override void OnException(IInvocation invocation, System.Exception exception)
        {
            Console.WriteLine($"{this.GetType().Namespace}: {exception}");
        }
    }
}
