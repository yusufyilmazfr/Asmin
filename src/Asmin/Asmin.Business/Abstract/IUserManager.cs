using Asmin.Core.Entities.Concrete;
using Asmin.Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Asmin.Entities.CustomEntities.Request.User;

namespace Asmin.Business.Abstract
{
    public interface IUserManager
    {
        IDataResult<User> Login(UserLoginRequest user);
        Task<IDataResult<User>> GetByIdAsync(int id);
        Task<IDataResult<List<User>>> GetListAsync();
        Task<IResult> AddAsync(User user);
        Task<IResult> UpdateAsync(User user);
        Task<IResult> RemoveAsync(User user);
        Task<IDataResult<int>> GetCountAsync();
        IDataResult<List<OperationClaim>> GetClaimsByUserId(int id);
    }
}
