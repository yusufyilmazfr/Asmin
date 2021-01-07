using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Asmin.Packages.AOP.Interceptor.Async;
using Castle.DynamicProxy;

namespace Asmin.Packages.AOP.Aspects.Transaction
{
    public class AsminUnitOfWorkAspectAsync : AsyncInterceptor
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();

                    transactionScope.Complete();
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose();
                }
            }
        }

        protected override async ValueTask InterceptAsync(IAsyncInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    await invocation.ProceedAsync();

                    transactionScope.Complete();
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose();
                }
            }
        }
    }
}
