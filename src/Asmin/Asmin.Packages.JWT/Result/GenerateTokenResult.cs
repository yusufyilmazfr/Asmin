using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Packages.JWT.Result
{
    /// <summary>
    /// Token result contains JWT token result.
    /// </summary>
    public class GenerateTokenResult
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
