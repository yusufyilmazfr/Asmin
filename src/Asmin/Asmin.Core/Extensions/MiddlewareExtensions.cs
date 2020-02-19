using Asmin.Core.Utilities.Middleware.API;
using Asmin.Core.Utilities.Middleware.MVC;
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

        public static IApplicationBuilder UseMVCExceptionMiddleware(this IApplicationBuilder app, string errorPageUrl)
        {
            return app.UseMiddleware<MVCExceptionMiddleware>(errorPageUrl);
        }
    }
}
