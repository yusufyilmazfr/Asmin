using Asmin.WebMVC.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asmin.WebMVC.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void UseIncomingVisitorCounter(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<IncomingVisitorCounter>();
        }
        public static void UseUserClaimsCarrierMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<UserClaimsCarrierMiddleware>();
        }
    }
}
