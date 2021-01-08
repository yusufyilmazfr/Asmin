using Asmin.Business.Abstract;
using Asmin.Core.Entities.Concrete;
using Asmin.Core.Extensions;
using Asmin.WebMVC.Constants;
using Asmin.WebMVC.Services.Session;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Asmin.WebMVC.Middleware
{
    public class UserClaimsCarrierMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserManager _userManager;
        private readonly ISessionService _sessionService;

        public UserClaimsCarrierMiddleware(RequestDelegate next, IUserManager userManager, ISessionService sessionService)
        {
            _next = next;
            _userManager = userManager;
            _sessionService = sessionService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (_sessionService.Any(SessionKey.CurrentUser))
            {
                var currentUser = _sessionService.GetObject<User>(SessionKey.CurrentUser);

                // TODO: Claim call operations will be taken to the Business layer later.

                var claimsResult = _userManager.GetClaimsByUserId(currentUser.Id);

                if (claimsResult.IsSuccess && claimsResult.Data != null)
                {
                    var claims = new List<Claim>();

                    foreach (var claim in claimsResult.Data)
                    {
                        claims.AddRole(claim.Name);
                    }

                    var claimsIdentity = new ClaimsIdentity(claims);

                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    context.User = claimsPrincipal;
                }
            }

            await _next(context);
        }
    }
}
