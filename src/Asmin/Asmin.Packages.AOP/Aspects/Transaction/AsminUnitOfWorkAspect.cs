using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Asmin.Packages.AOP.Interceptor;
using Castle.DynamicProxy;

namespace Asmin.Packages.AOP.Aspects.Transaction
{
    /// <summary>
    /// AsminUnitOfWorkAspect works when method is work unsuccessfully. Throws expected exception after transaction.
    /// </summary>
    public class AsminUnitOfWorkAspect : MethodInterceptor
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
                    throw;
                }
            }
        }
    }
}
