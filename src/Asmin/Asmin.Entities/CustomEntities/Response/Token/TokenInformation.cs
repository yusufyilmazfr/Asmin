using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Entities.CustomEntities.Response.Token
{
    /// <summary>
    /// Token result contains JWT token result.
    /// </summary>
    public class TokenInformation
    {
        /// <summary>
        /// Generated token.
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Expiry date of token.
        /// </summary>
        public DateTime ExpiryDate { get; set; }
    }
}
