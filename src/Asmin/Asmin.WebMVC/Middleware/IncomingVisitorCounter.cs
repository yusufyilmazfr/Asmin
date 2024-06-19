using Asmin.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Asmin.WebMVC.Services.Rest.IncomingVisitorService;

namespace Asmin.WebMVC.Middleware
{
    /// <summary>
    /// Incoming visitor middleware provides to increase visitor count from database for each request.
    /// </summary>
    public class IncomingVisitorCounter
    {
        private readonly RequestDelegate _next;
        private readonly IIncomingVisitorApiService _incomingVisitorApiService;

        public IncomingVisitorCounter(RequestDelegate next, IIncomingVisitorApiService incomingVisitorApiService)
        {
            _next = next;
            _incomingVisitorApiService = incomingVisitorApiService;
        }

        /// <summary>
        /// Request invocation. You can use any queue mechanism for async operation. It uses api by default.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            var visitor = new IncomingVisitor
            {
                IpAddress = context.Connection.RemoteIpAddress.ToString()
            };

            _ = _incomingVisitorApiService.AddAsync(visitor);

            await _next(context);
        }
    }
}
