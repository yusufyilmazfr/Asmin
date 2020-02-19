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
        private const string SERVER_ERROR_MESSAGE = "Unexpected server error.";
        private const string ASPECT_ERROR_MESSAGE = "Unexpected server error, please try again.";

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
