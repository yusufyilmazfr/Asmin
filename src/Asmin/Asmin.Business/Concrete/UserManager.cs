using Asmin.Business.Abstract;
using Asmin.Core.Aspects.Autofac.Caching;
using Asmin.Core.Aspects.Autofac.Logging;
using Asmin.Core.Aspects.Autofac.Transaction;
using Asmin.Core.Constants.Messages;
using Asmin.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Asmin.Core.Entities.Concrete;
using Asmin.Core.Utilities.Result;
using Asmin.DataAccess.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asmin.Business.Concrete
{
    public class UserManager : IUserManager
    {
        private IUserDal _userDal;
        private IValidator<User> _userValidator;
        public UserManager(IUserDal userDal, IValidator<User> userValidator)
        {
            _userDal = userDal;
            _userValidator = userValidator;
        }

        [CacheRemoveAspect("IUserManager.Get")]
        [LogAspect(typeof(FileLogger))] 
        public async Task<IResult> AddAsync(User user)
        {
            var validationResult = _userValidator.Validate(user);

            if (!validationResult.IsValid)
            {
                var firstErrorMessage = validationResult.Errors.Select(failure => failure.ErrorMessage).FirstOrDefault();
                return new ErrorResult(firstErrorMessage);
            }

            await _userDal.AddAsnyc(user);
            return new SuccessResult(ResultMessages.UserAdded);
        }

        [CacheAspect]
        public async Task<IDataResult<User>> GetByIdAsync(int id)
        {
            var user = await _userDal.GetByIdAsync(id);
            return new SuccessDataResult<User>(user);
        }

        [CacheAspect]
        [LogAspect(typeof(FileLogger))]
        public async Task<IDataResult<List<User>>> GetListAsync()
        {
            var users = await _userDal.GetListAsync();
            return new SuccessDataResult<List<User>>(users);
        }

        public async Task<IResult> RemoveAsync(User user)
        {
            await _userDal.RemoveAsnyc(user);
            return new SuccessResult(ResultMessages.UserRemoved);
        }

        public async Task<IResult> UpdateAsync(User user)
        {
            await _userDal.UpdateAsnyc(user);
            return new SuccessResult(ResultMessages.UserUpdated);
        }

        [AsminUnitOfWorkAspect]
        public void TransactionalTestMethod()
        {
            User user1 = new User
            {
                FirstName = "Asmin",
                LastName = "Yılmaz",
                Email = "yusufyilmazfr@gmail.com",
                Password = "123"
            };

            User user2 = new User
            {
                Email = "yusufyilmazfr@gmail.com",
                Password = "123"
            };

            _userDal.Add(user1);
            _userDal.Add(user2);
        }
    }
}
