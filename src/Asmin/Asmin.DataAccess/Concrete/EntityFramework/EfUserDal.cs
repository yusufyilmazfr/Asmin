using Asmin.Core.Entities.Concrete;
using Asmin.DataAccess.Abstract;
using Asmin.DataAccess.Concrete.EntityFramework.Context;
using Asmin.DataAccess.Concrete.EntityFramework.Repository;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfRepositoryBase<User, AsminDbContext>, IUserDal
    {
        public List<OperationClaim> GetClaimsByUserId(int id)
        {
            using (AsminDbContext context = new AsminDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };

                return result.ToList();
            }
        }
    }
}
