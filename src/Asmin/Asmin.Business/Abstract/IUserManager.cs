using Asmin.Core.Entities.Concrete;
using Asmin.Core.Utilities.Result;
using Asmin.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asmin.Business.Abstract
{
    public interface IUserManager
    {
        Task<IDataResult<User>> Login(UserLoginDto user);
        Task<IDataResult<User>> GetByIdAsync(int id);
        Task<IDataResult<List<User>>> GetListAsync();
        Task<IResult> AddAsync(User user);
        Task<IResult> UpdateAsync(User user);
        Task<IResult> RemoveAsync(User user);
        Task<IDataResult<int>> GetCountAsync();
        void TransactionalTestMethod();
    }
}
