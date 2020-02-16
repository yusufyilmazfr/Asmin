using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.Entities.Concrete
{
    public class UserOperationClaim : BaseEntity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
