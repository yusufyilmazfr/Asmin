using Asmin.Business.Abstract;
using Asmin.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asmin.WebMVC.Middleware
{
    public class IncomingVisitorCounter
    {
        private RequestDelegate _next;
        private IIncomingVisitorManager _incomingVisitorManager;

        public IncomingVisitorCounter(RequestDelegate next, IIncomingVisitorManager incomingVisitorManager)
        {
            _next = next;
            _incomingVisitorManager = incomingVisitorManager;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var visitor = new IncomingVisitor();
            visitor.IpAddress = context.Connection.RemoteIpAddress.ToString();

            _incomingVisitorManager.AddAsync(visitor);

            await _next(context);
        }
    }
}
