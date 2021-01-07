using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Asmin.Packages.AOP.Interceptor.Async
{
    public static class Awaiter
    {
        public static object GetAwaiter(this object awaitable)
        {
            // TODO: `.GetAwaiter()` extension methods are not yet supported!
            var getAwaiterMethod = awaitable.GetType().GetMethod("GetAwaiter", BindingFlags.Public | BindingFlags.Instance);
            return getAwaiterMethod.Invoke(awaitable, null);
        }

        public static bool IsCompleted(this object awaiter)
        {
            var isCompletedProperty = awaiter.GetType().GetProperty("IsCompleted", BindingFlags.Public | BindingFlags.Instance);
            return (bool)isCompletedProperty.GetValue(awaiter);
        }

        public static void OnCompleted(this object awaiter, Action continuation)
        {
            var onCompletedMethod = awaiter.GetType().GetMethod("OnCompleted", BindingFlags.Public | BindingFlags.Instance);
            onCompletedMethod.Invoke(awaiter, new object[] { continuation });
        }

        public static object GetResult(this object awaiter)
        {
            var getResultMethod = awaiter.GetType().GetMethod("GetResult", BindingFlags.Public | BindingFlags.Instance);
            return getResultMethod.Invoke(awaiter, null);
        }
    }
}
