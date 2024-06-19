using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Asmin.Business.Abstract;
using Asmin.Core.Entities.Concrete;
using Asmin.Core.Utilities.Result;
using Asmin.DataAccess.Abstract;

namespace Asmin.Business.Concrete
{
    class OperationClaimManager : IOperationClaimManager
    {
        private readonly IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public async Task<IDataResult<List<OperationClaim>>> GetClaimsAsync()
        {
            var claims = await _operationClaimDal.GetListAsync();
            return new SuccessDataResult<List<OperationClaim>>(claims);
        }
    }
}
