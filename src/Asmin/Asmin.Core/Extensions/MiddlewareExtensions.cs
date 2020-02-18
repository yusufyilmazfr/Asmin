using Asmin.Core.Utilities.Middleware.API;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseAPIExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<APIExceptionMiddleware>();
        }
    }
}
