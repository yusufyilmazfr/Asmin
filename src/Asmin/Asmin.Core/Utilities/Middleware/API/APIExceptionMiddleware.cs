using Asmin.Core.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asmin.Core.Utilities.Middleware.API
{
    public class APIExceptionMiddleware
    {
        public readonly RequestDelegate _next;

        private const string SERVER_ERROR_MESSAGE = "Unexpected server error.";

        public APIExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            object message = null;

            try
            {
                await _next(context);
            }
            catch (AuthorizationException e)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                message = new ExceptionMessage(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                message = new ExceptionMessage(StatusCodes.Status500InternalServerError, SERVER_ERROR_MESSAGE);
            }

            if (message != null)
            {
                await context.Response.WriteAsync(JsonConvert.SerializeObject(message));
            }
        }
    }
}

