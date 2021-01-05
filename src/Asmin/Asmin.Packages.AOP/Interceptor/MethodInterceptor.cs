using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace Asmin.Packages.AOP.Interceptor
{
    public class MethodInterceptor : MethodInterceptorBase
    {
        public virtual void OnBefore(IInvocation invocation) { }
        public virtual void OnAfter(IInvocation invocation) { }
        public virtual void OnSuccess(IInvocation invocation) { }
        public virtual void OnException(IInvocation invocation, Exception exception) { }

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
