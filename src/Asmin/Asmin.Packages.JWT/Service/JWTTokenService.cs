using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Asmin.Packages.JWT.Configuration;
using Asmin.Packages.JWT.Entities;
using Asmin.Packages.JWT.Result;
using Microsoft.IdentityModel.Tokens;

namespace Asmin.Packages.JWT.Service
{
    public class JWTTokenService : ITokenService
    {
        private readonly IJWTConfiguration _configuration;

        public JWTTokenService(IJWTConfiguration configuration)
        {
            _configuration = configuration;
        }

        public GenerateTokenResult Generate(List<ClaimKeyValuePair> claimKeyValuePairs)
        {
            var tokenResult = new GenerateTokenResult();
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration.SecretKey);

            tokenResult.ExpiryDate = DateTime.Now.AddHours(_configuration.ExpiryHour);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaimsIdentityList(claimKeyValuePairs),
                Expires = tokenResult.ExpiryDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), GetEnumDescription(_configuration.TokenSecurityAlgorithms)),
                Issuer = _configuration.Issuer,
                Audience = _configuration.Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            tokenResult.Token = tokenHandler.WriteToken(token);

            return tokenResult;
        }

        private ClaimsIdentity GenerateClaimsIdentityList(IEnumerable<ClaimKeyValuePair> keyValuePairs)
        {
            var claims = keyValuePairs.Select(keyValuePair => new Claim(keyValuePair.Key, keyValuePair.Value));

            return new ClaimsIdentity(claims);
        }

        public string GetEnumDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] descriptionAttributes && descriptionAttributes.Any())
            {
                return descriptionAttributes[0].Description;
            }

            return value.ToString();
        }
    }
}
