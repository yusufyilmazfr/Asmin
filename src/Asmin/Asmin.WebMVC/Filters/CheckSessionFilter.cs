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
    /// <summary>
    /// Check current user exists.
    /// </summary>
    public class CheckSessionFilter : ActionFilterAttribute
    {
        private readonly ISessionService _sessionService;

        public CheckSessionFilter(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (CheckMethodContainsAllowAnySessionFilter(context))
            {
                return;
            }

            var isUserLoggedIn = _sessionService.Any(SessionKey.CurrentUser);

            if (!isUserLoggedIn)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller" , "Home" } ,
                    {"action" , "Login"}
                });
            }
        }

        private bool CheckMethodContainsAllowAnySessionFilter(ResultExecutingContext context)
        {
            return context.Filters.Any(filter => filter.GetType().Name == nameof(AllowAnySessionFilter));
        }
    }
}
