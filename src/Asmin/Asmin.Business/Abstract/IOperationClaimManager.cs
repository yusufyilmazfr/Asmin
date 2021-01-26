using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Asmin.Core.Entities.Concrete;
using Asmin.Core.Utilities.Result;

namespace Asmin.Business.Abstract
{
    public interface IOperationClaimManager
    {
        /// <summary>
        /// Returns all claims.
        /// </summary>
        /// <returns></returns>
        Task<IDataResult<List<OperationClaim>>> GetClaimsAsync();
    }
}
