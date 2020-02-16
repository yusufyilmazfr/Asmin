using Asmin.Core.CrossCuttingConcerns.Caching;
using Asmin.Core.Utilities.Interceptor;
using Asmin.Core.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheService _cacheService;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheService = DependencyServiceTool.ServiceProvider.GetService<ICacheService>();
        }

        public override void OnSuccess(IInvocation invocation)
        {
            _cacheService.RemoveByPattern(_pattern);
        }
    }
}
