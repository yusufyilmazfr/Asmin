using Asmin.Business.Abstract;
using Asmin.Core.Constants.Messages;
using Asmin.Core.Entities.Concrete;
using Asmin.Core.Extensions;
using Asmin.Core.Utilities.Result;
using Asmin.DataAccess.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asmin.Entities.CustomEntities.Request.User;
using Asmin.Packages.AOP.Aspects.Exception;
using Asmin.Packages.AOP.Aspects.Transaction;
using Asmin.Packages.Hashing.Core.Service;

namespace Asmin.Business.Concrete
{
    public class UserManager : IUserManager
    {
        private readonly IUserDal _userDal;
        private readonly IHashService _hashService;
        private readonly IValidator<User> _userValidator;

        public UserManager(IUserDal userDal, IValidator<User> userValidator, IHashService hashService)
        {
            _userDal = userDal;
            _userValidator = userValidator;
            _hashService = hashService;
        }

        [AsminExceptionAspect]
        [AsminUnitOfWorkAspect]
        public async Task<IResult> AddAsync(User user)
        {
            var validationResult = await _userValidator.ValidateAsync(user);

            if (!validationResult.IsValid)
            {
                var firstErrorMessage = validationResult.Errors.Select(failure => failure.ErrorMessage).FirstOrDefault();
                return new ErrorResult(firstErrorMessage);
            }

            user.Password = _hashService.Generate(user.Password);

            await _userDal.AddAsync(user);
            return new SuccessResult(ResultMessages.UserAdded);
        }

        public async Task<IDataResult<User>> GetByIdAsync(int id)
        {
            var user = await _userDal.GetByIdAsync(id);
            return new SuccessDataResult<User>(user);
        }

        public async Task<IDataResult<List<User>>> GetListAsync()
        {
            var users = await _userDal.GetListAsync();
            return new SuccessDataResult<List<User>>(users);
        }

        public async Task<IResult> RemoveAsync(User user)
        {
            await _userDal.RemoveAsync(user);
            return new SuccessResult(ResultMessages.UserRemoved);
        }

        public async Task<IResult> UpdateAsync(User user)
        {
            await _userDal.UpdateAsync(user);
            return new SuccessResult(ResultMessages.UserUpdated);
        }

        public IDataResult<User> Login(UserLoginRequest user)
        {
            var hashedPassword = _hashService.Generate(user.Password);

            User tempUser = _userDal.GetUser(user.Email, hashedPassword);

            return new SuccessDataResult<User>(tempUser?.WithoutPassword());
        }

        public async Task<IDataResult<int>> GetCountAsync()
        {
            var usersCount = await _userDal.GetCountAsync();
            return new SuccessDataResult<int>(usersCount);
        }

        public IDataResult<List<OperationClaim>> GetClaimsByUserId(int id)
        {
            var claims = _userDal.GetClaimsByUserId(id);
            return new SuccessDataResult<List<OperationClaim>>(claims);
        }
    }
}
