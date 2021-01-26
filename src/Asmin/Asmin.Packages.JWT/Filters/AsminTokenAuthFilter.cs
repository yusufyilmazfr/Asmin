using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Asmin.Packages.JWT.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Asmin.Packages.JWT.Filters
{
    /// <summary>
    /// Check request is valid.
    /// Token has valid expiry date or token key is valid.
    /// It writes 401 Unauthorized status code when token invalid. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AsminTokenAuthFilter : ActionFilterAttribute
    {
        public ITokenService TokenService => _tokenService;

        private readonly ITokenService _tokenService;

        public AsminTokenAuthFilter(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Ignore validation when action contains AsminIgnoreTokenAuthFilter
            if (CheckMethodContainsAsminIgnoreTokenAuthFilter(context))
            {
                return;
            }

            // Get Bearer token.
            var token = context.HttpContext.Request.Headers["Authorization"];

            // Write message when token is empty.
            if (String.IsNullOrEmpty(token))
            {
                WriteUnauthorizationMessage(context, new ArgumentException("Token can not be empty!"));
                return;
            }

            try
            {
                // Get token without Bearer keyword.
                var tokenWithoutBearerKeyword = token.ToString().Split(' ')[1];

                // Resolve token. Token service returns token status and claims.
                var resolveTokenResult = _tokenService.ResolveToken(tokenWithoutBearerKeyword);

                // Write message when token is invalid.
                if (!resolveTokenResult.IsValid)
                {
                    WriteUnauthorizationMessage(context, new Exception(resolveTokenResult.ErrorMessage));
                    return;
                }
            }
            catch (Exception e)
            {
                WriteUnauthorizationMessage(context, new Exception("Invalid token!"));
                return;
            }
        }

        /// <summary>
        /// Check action has AsminIgnoreTokenAuthFilter.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private bool CheckMethodContainsAsminIgnoreTokenAuthFilter(ActionExecutingContext context)
        {
            return context.Filters.Any(filter => filter.GetType().Name == nameof(AsminIgnoreTokenAuthFilter));
        }

        /// <summary>
        /// It writes 401 Unauthorized status code when token invalid. 
        /// </summary>
        /// <param name="context">ActionExecutingContext</param>
        /// <param name="exception">Exception message.</param>
        protected virtual void WriteUnauthorizationMessage(ActionExecutingContext context, Exception exception)
        {
            var objectResult = new ObjectResult(new
            {
                errorMessage = exception.Message,
                IsSuccess = false
            });

            objectResult.StatusCode = 401;

            context.Result = objectResult;
        }
    }
}
