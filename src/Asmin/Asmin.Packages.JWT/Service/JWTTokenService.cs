using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Xml;
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

        public GenerateTokenResult Generate(IEnumerable<Claim> claims)
        {
            var tokenResult = new GenerateTokenResult();
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration.SecretKey);

            tokenResult.ExpiryDate = DateTime.Now.AddHours(_configuration.ExpiryHour);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaimsIdentityList(claims),
                Expires = tokenResult.ExpiryDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), GetEnumDescription(_configuration.TokenSecurityAlgorithms)),
                Issuer = _configuration.Issuer,
                Audience = _configuration.Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            tokenResult.Token = tokenHandler.WriteToken(token);

            return tokenResult;
        }

        public ResolveTokenResult ResolveToken(string token)
        {
            var resolveTokenResult = new ResolveTokenResult();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.SecretKey);
            var securityKey = new SymmetricSecurityKey(key);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = _configuration.Audience,
                    ValidIssuer = _configuration.Issuer,
                    IssuerSigningKey = securityKey
                }, out SecurityToken validatedToken);

                resolveTokenResult.ExpiryDate = validatedToken.ValidTo;
                resolveTokenResult.IsValid = true;
                resolveTokenResult.Claims = tokenHandler.ReadJwtToken(token).Claims;
            }

            catch (Exception ex)
            {
                resolveTokenResult.IsValid = false;
                resolveTokenResult.ErrorMessage = ex.Message;
            }

            return resolveTokenResult;
        }

        private ClaimsIdentity GenerateClaimsIdentityList(IEnumerable<Claim> claims)
        {
            return new ClaimsIdentity(claims);
        }

        private string GetEnumDescription(Enum value)
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
