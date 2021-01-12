using Asmin.Packages.JWT.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Entities.CustomEntities.Response.User
{
    /// <summary>
    /// User login response.
    /// </summary>
    public class UserLoginResponse
    {
        /// <summary>
        /// Current user information.
        /// </summary>
        public Core.Entities.Concrete.User User { get; set; }
        /// <summary>
        /// Token information. It contains token, expiry date.
        /// </summary>
        public GenerateTokenResult TokenInformation { get; set; }
    }
}
