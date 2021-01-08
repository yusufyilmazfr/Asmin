using System;
using System.Collections.Generic;
using System.Text;
using Asmin.Packages.JWT.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Asmin.Packages.JWT.Configuration
{
    public class JWTConfiguration : IJWTConfiguration
    {
        public string SecretKey { get; set; }
        public int ExpiryHour { get; set; }
        public EnumTokenSecurityAlgorithms TokenSecurityAlgorithms { get; set; }
    }
}
