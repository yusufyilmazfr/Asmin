using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.Utilities.Interceptor
{
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }
        public abstract void Intercept(IInvocation invocation);
    }
}
