using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Asmin.Core.Extensions
{
    public static class ClaimsExtensions
    {
        private static string ROLE_TYPE = "UserRole";

        public static void AddRole(this List<Claim> claims, string role)
        {
            claims.Add(new Claim(ROLE_TYPE, role));
        }

        public static List<string> GetRoles(this List<Claim> claims)
        {
            return claims.Where(i => i.Type == ROLE_TYPE).Select(i => i.Value).ToList();
        }
    }
}
