using Asmin.Core.Utilities.Hash;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.DependencyModules
{
    public class MD5HashModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddSingleton<IHashService, MD5HashService>();
        }
    }
}
