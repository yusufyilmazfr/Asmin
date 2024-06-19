using System;
using System.Collections.Generic;
using System.Text;
using Asmin.Entities.CustomEntities.Response.Token;

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
        public TokenInformation TokenInformation { get; set; }

        public UserLoginResponse()
        {
            TokenInformation = new TokenInformation();
        }
    }
}
