using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Entities.CustomEntities.Request.User
{
    /// <summary>
    /// It contains required fields for insert user to database.
    /// </summary>
    public class InsertUserRequest
    {
        /// <summary>
        /// User first name.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// User last name.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// User password. It must be unique.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password. It must be plain text.
        /// </summary>
        public string Password { get; set; }
    }
}
