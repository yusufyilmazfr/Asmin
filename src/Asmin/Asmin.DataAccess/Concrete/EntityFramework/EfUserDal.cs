using Asmin.Core.Entities.Concrete;
using Asmin.DataAccess.Abstract;
using Asmin.DataAccess.Concrete.EntityFramework.Context;
using Asmin.DataAccess.Concrete.EntityFramework.Repository;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Asmin.Core.Configuration.Context;

namespace Asmin.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfRepositoryBase<User, int>, IUserDal
    {
        private readonly IAsminConfigurationContext _asminConfigurationContext;

        public EfUserDal(IAsminConfigurationContext asminConfigurationContext) : base(asminConfigurationContext.ConnectionString)
        {
            _asminConfigurationContext = asminConfigurationContext;
        }

        public List<OperationClaim> GetClaimsByUserId(int id)
        {
            using (AsminDbContext context = new AsminDbContext(_asminConfigurationContext.ConnectionString))
            {
                return context
                    .UserOperationClaims
                        .Where(userOperationClaim => userOperationClaim.UserId == id)
                    .Select(userOperationClaim => userOperationClaim.OperationClaim)
                    .ToList();
            }
        }

        public User GetUser(string email, string password)
        {
            using (var context = new AsminDbContext(_asminConfigurationContext.ConnectionString))
            {
                return context.Users.FirstOrDefault(user => user.Email == email && user.Password == password);
            }
        }
    }
}
