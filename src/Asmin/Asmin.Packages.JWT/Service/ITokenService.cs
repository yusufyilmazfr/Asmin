using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Asmin.Packages.JWT.Entities;
using Asmin.Packages.JWT.Result;

namespace Asmin.Packages.JWT.Service
{
    public interface ITokenService
    {
        /// <summary>
        /// Generate JWT token with specified claims.
        /// </summary>
        /// <param name="claimKeyValuePairs">Claim key value pairs.</param>
        /// <returns></returns>
        GenerateTokenResult Generate(List<ClaimKeyValuePair> claimKeyValuePairs);
    }
}
