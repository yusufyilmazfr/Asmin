using Asmin.Business.Abstract;
using Asmin.Core.Constants.ResultMessages;
using Asmin.Core.Utilities.Result;
using Asmin.DataAccess.Abstract;
using Asmin.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asmin.Business.Concrete
{
    public class UserManager : IUserManager
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public async Task<IResult> AddAsync(User user)
        {
            await _userDal.AddAsnyc(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IDataResult<User> GetById(int id)
        {
            var user = _userDal.GetById(id);
            return new SuccessDataResult<User>(user);
        }

        public async Task<IDataResult<User>> GetByIdAsync(int id)
        {
            var user = await _userDal.GetByIdAsync(id);
            return new SuccessDataResult<User>(user);
        }

        public IDataResult<List<User>> GetList()
        {
            var users = _userDal.GetList();
            return new SuccessDataResult<List<User>>(users);
        }

        public async Task<IDataResult<List<User>>> GetListAsync()
        {
            var users = await _userDal.GetListAsync();
            return new SuccessDataResult<List<User>>(users);
        }

        public IResult Remove(User user)
        {
            _userDal.Remove(user);
            return new SuccessResult(Messages.UserRemoved);
        }

        public async Task<IResult> RemoveAsync(User user)
        {
            await _userDal.RemoveAsnyc(user);
            return new SuccessResult(Messages.UserRemoved);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public async Task<IResult> UpdateAsync(User user)
        {
            await _userDal.UpdateAsnyc(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
