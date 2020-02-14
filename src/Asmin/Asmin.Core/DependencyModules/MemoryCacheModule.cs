using Asmin.Core.CrossCuttingConcerns.Caching;
using Asmin.Core.CrossCuttingConcerns.Caching.MicrosoftMemoryCache;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.DependencyModules
{
    public class MemoryCacheModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheService, MemoryCacheService>();
        }
    }
}
