using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.DependencyModules
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
