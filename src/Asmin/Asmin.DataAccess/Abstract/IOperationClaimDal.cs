using System;
using System.Collections.Generic;
using System.Text;
using Asmin.Core.Entities.Concrete;
using Asmin.DataAccess.Abstract.Repository;

namespace Asmin.DataAccess.Abstract
{
    public interface IOperationClaimDal : IRepository<OperationClaim, int>
    {
    }
}
