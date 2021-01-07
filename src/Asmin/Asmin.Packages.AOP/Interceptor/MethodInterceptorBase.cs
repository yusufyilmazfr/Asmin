using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace Asmin.Packages.AOP.Interceptor
{
    public abstract class MethodInterceptorBase : Attribute, IInterceptor
    {
        /// <summary>
        /// Working priority
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// Intercept defined method
        /// </summary>
        /// <param name="invocation"></param>
        public abstract void Intercept(IInvocation invocation);
    }
}
