using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Asmin.Packages.AOP.Interceptor.Async
{
    public abstract partial class AsyncInterceptor : MethodInterceptorBase, IInterceptor
    {
        void IInterceptor.Intercept(IInvocation invocation)
        {
            var returnType = invocation.Method.ReturnType;
            var builder = AsyncMethodBuilder.TryCreate(returnType);
            if (builder != null)
            {
                var asyncInvocation = new AsyncInvocation(invocation);
                var stateMachine = new AsyncStateMachine(asyncInvocation, builder, task: this.InterceptAsync(asyncInvocation));
                builder.Start(stateMachine);
                invocation.ReturnValue = builder.Task();
            }
            else
            {
                this.Intercept(invocation);
            }
        }

        public abstract override void Intercept(IInvocation invocation);

        protected abstract ValueTask InterceptAsync(IAsyncInvocation invocation);
    }
}
