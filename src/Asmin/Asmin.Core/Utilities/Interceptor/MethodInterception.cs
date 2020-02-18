using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.Utilities.Interceptor
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {
        public virtual void OnBefore(IInvocation invocation) { }
        public virtual void OnAfter(IInvocation invocation) { }
        public virtual void OnSuccess(IInvocation invocation) { }
        public virtual void OnException(IInvocation invocation, Exception e) { }
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
                throw;
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
