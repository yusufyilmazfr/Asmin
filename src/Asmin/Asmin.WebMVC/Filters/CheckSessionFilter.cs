using Asmin.WebMVC.Constants;
using Asmin.WebMVC.Services.Session;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asmin.WebMVC.Filters
{
    public class CheckSessionFilter : Attribute, IActionFilter
    {
        private ISessionService _sessionService;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //var any = context
            //    .ActionDescriptor
            //    .EndpointMetadata.Select(i => i.GetType().FullName == typeof(SkipCheckSessionFilter).FullName).Any();

            //if (any)
            //{
            //    return;
            //}

            _sessionService = context.HttpContext.RequestServices.GetService<ISessionService>();

            var isUserLoggedIn = _sessionService.Any(SessionKey.CURRENT_USER);

            if (!isUserLoggedIn)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller","Home" },{"action","Login"}
                });
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
