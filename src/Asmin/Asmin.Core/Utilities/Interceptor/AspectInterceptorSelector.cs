using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Asmin.Core.Utilities.Interceptor
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true)
                .ToList();

            var methodAttributes = type
            .GetMethod(method.Name)
            .GetCustomAttributes<MethodInterceptionBaseAttribute>(true)
            .ToList();

            classAttributes.AddRange(methodAttributes);

            return classAttributes.OrderBy(i => i.Priority).ToArray();
        }
    }
}
