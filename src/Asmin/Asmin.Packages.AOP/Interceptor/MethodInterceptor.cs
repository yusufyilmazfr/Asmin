using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace Asmin.Packages.AOP.Interceptor
{
    /// <summary>
    /// MethodInterceptor provides writing aspect.
    /// </summary>
    public class MethodInterceptor : MethodInterceptorBase
    {
        /// <summary>
        /// OnBefore works before method working
        /// </summary>
        /// <param name="invocation"></param>
        public virtual void OnBefore(IInvocation invocation) { }

        /// <summary>
        /// OnAfter works last
        /// </summary>
        /// <param name="invocation"></param>
        public virtual void OnAfter(IInvocation invocation) { }

        /// <summary>
        /// OnSuccess works when method done successfully
        /// </summary>
        /// <param name="invocation"></param>
        public virtual void OnSuccess(IInvocation invocation) { }

        /// <summary>
        /// OnException works when method throws exception
        /// </summary>
        /// <param name="invocation"></param>
        /// <param name="exception">Throwed exception</param>
        public virtual void OnException(IInvocation invocation, Exception exception) { }

        /// <summary>
        /// Intercept works while method is working
        /// </summary>
        /// <param name="invocation"></param>
        public override void Intercept(IInvocation invocation)
        {
            bool isSuccess = true;

            OnBefore(invocation);

            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;

                OnException(invocation, e);
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }

                OnAfter(invocation);
            }
        }
    }
}
