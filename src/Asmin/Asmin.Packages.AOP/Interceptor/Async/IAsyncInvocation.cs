using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Asmin.Packages.AOP.Interceptor.Async
{
    public interface IAsyncInvocation
    {
        IReadOnlyList<object> Arguments { get; }
        MethodInfo Method { get; }
        object Result { get; set; }
        ValueTask ProceedAsync();
    }
}
