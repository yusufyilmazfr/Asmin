using Asmin.Core.CrossCuttingConcerns.Caching;
using Asmin.Core.Utilities.Interceptor;
using Asmin.Core.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asmin.Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _timeout;
        private readonly ICacheService _cacheService;

        public CacheAspect(int timeout = 60)
        {
            _timeout = timeout;
            _cacheService = DependencyServiceTool.ServiceProvider.GetService<ICacheService>();
        }

        public override void OnBefore(IInvocation invocation)
        {
            //fullname contains namespace with method name
            var fullName = $"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}";

            var arguments = invocation.Arguments.ToArray();

            var key = $"{fullName}({JsonConvert.SerializeObject(arguments)})";

            if (_cacheService.Any(key))
            {
                invocation.ReturnValue = _cacheService.Get(key);
            }
            else
            {
                invocation.Proceed();

                _cacheService.Add(key, invocation.ReturnValue, _timeout);
            }
        }
    }
}
