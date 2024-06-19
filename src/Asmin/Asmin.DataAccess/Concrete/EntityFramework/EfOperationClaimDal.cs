using System;
using System.Collections.Generic;
using System.Text;
using Asmin.Core.Configuration.Context;
using Asmin.Core.Entities.Concrete;
using Asmin.DataAccess.Abstract;
using Asmin.DataAccess.Concrete.EntityFramework.Repository;

namespace Asmin.DataAccess.Concrete.EntityFramework
{
    class EfOperationClaimDal : EfRepositoryBase<OperationClaim, int>, IOperationClaimDal
    {
        private readonly IAsminConfigurationContext _asminConfigurationContext;

        public EfOperationClaimDal(IAsminConfigurationContext asminConfigurationContext) : base(asminConfigurationContext.ConnectionString)
        {

        }
    }
}
