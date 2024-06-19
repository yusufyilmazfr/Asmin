using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.Entities.Concrete
{
    /// <summary>
    /// User entity.
    /// </summary>
    public class User : BaseEntity<int>
    {
        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Hashed password.
        /// </summary>
        public string Password { get; set; }

        public List<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
