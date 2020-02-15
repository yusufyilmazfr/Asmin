﻿using Castle.DynamicProxy;
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
        public virtual void OnException(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            bool isSuccess = true;

            try
            {
                OnBefore(invocation);
            }
            catch (Exception e)
            {
                isSuccess = false;

                OnException(invocation);
                throw e;
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
