using Asmin.Core.CrossCuttingConcerns.Caching;
using Asmin.Core.CrossCuttingConcerns.Caching.RedisCache;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.DependencyModules
{
    public class RedisCacheModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddSingleton<RedisServer>();
            services.AddSingleton<ICacheService, RedisMemoryCacheService>();
        }
    }
}
