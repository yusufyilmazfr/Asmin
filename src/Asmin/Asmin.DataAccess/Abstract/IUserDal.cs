using Asmin.Core.Entities.Concrete;
using Asmin.DataAccess.Abstract.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.DataAccess.Abstract
{
    public interface IUserDal : IRepository<User>
    {
        List<OperationClaim> GetClaimsByUserId(int id);
    }
}
