using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Entities.CustomEntities.Request.User
{
    /// <summary>
    /// It contains required fields for update user from database.
    /// </summary>
    public class UpdateUserRequest
    {
        /// <summary>
        /// Unique user id.
        /// </summary>
        public int Id { get; set; }
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
    }
}
