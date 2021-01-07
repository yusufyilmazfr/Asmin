using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.Entities.Concrete
{
    /// <summary>
    /// User-Claim pair.
    /// </summary>
    public class UserOperationClaim : BaseEntity<int>
    {
        /// <summary>
        /// User Id.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Operation Claim Id.
        /// </summary>
        public int OperationClaimId { get; set; }

        public User User { get; set; }
        public OperationClaim OperationClaim { get; set; }
    }
}
