using Asmin.Core.Constants.Messages;
using Asmin.Core.Extensions;
using Asmin.Core.Utilities.Interceptor;
using Asmin.Core.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asmin.Core.Aspects.Autofac.Authorization
{
    public class AuthorizationAspect : MethodInterception
    {
        private IHttpContextAccessor _httpContextAccessor;
        private string _roles;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roles">Roles can be separated by commas</param>
        public AuthorizationAspect(string roles)
        {
            _roles = roles;
            _httpContextAccessor = DependencyServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        public override void OnBefore(IInvocation invocation)
        {
            var currentUserClaims = _httpContextAccessor.HttpContext.User?.Claims.ToList();
            var currentUserRoles = currentUserClaims?.GetRoles();

            var roles = _roles.Split(',');

            foreach (var userRole in currentUserRoles)
            {
                if (roles.Contains(userRole))
                {
                    return;
                }
            }


            throw new Exception(AspectMessages.AuthorizeDenied);
        }
    }
}
