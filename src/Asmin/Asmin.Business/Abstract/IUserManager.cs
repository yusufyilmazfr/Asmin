using Asmin.Core.Utilities.Result;
using Asmin.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asmin.Business.Abstract
{
    public interface IUserManager
    {
        IDataResult<User> GetById(int id);
        IDataResult<List<User>> GetList();
        IResult Add(User user);
        IResult Update(User user);
        IResult Remove(User user);
        Task<IDataResult<User>> GetByIdAsync(int id);
        Task<IDataResult<List<User>>> GetListAsync();
        Task<IResult> AddAsync(User user);
        Task<IResult> UpdateAsync(User user);
        Task<IResult> RemoveAsync(User user);
    }
}
