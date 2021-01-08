using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.Entities.Concrete
{
    /// <summary>
    /// OperationClaim means operation role. It can be role suc as admin, user or method claim such as InsertNewUser, AddUser etc.
    /// </summary>
    public class OperationClaim : BaseEntity<int>
    {
        /// <summary>
        /// Claim name.
        /// </summary>
        public string Name { get; set; }

        public List<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
