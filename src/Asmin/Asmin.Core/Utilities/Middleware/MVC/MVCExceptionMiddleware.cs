using Asmin.Core.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asmin.Core.Utilities.Middleware.MVC
{
    public class MVCExceptionMiddleware
    {
        private string _errorPageUrl;

        private RequestDelegate _next;

        public MVCExceptionMiddleware(RequestDelegate next, string errorPageUrl)
        {
            _next = next;
            _errorPageUrl = errorPageUrl;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                context.Response.Redirect(_errorPageUrl);
            }
        }
    }
}
