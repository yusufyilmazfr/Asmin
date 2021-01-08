using Asmin.Business.Abstract;
using Asmin.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asmin.WebMVC.Middleware
{
    /// <summary>
    /// Incoming visitor middleware provides to increase visitor count from database for each request.
    /// </summary>
    public class IncomingVisitorCounter
    {
        private readonly RequestDelegate _next;
        private readonly IIncomingVisitorManager _incomingVisitorManager;

        public IncomingVisitorCounter(RequestDelegate next, IIncomingVisitorManager incomingVisitorManager)
        {
            _next = next;
            _incomingVisitorManager = incomingVisitorManager;
        }

        /// <summary>
        /// Request invocation. You can use any queue mechanism for async operation. It uses database by default.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            var visitor = new IncomingVisitor
            {
                IpAddress = context.Connection.RemoteIpAddress.ToString()
            };

            await _incomingVisitorManager.AddAsync(visitor);

            await _next(context);
        }
    }
}
