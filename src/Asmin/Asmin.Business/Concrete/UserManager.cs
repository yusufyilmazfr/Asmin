using Asmin.Business.Abstract;
using Asmin.Core.Constants.Messages;
using Asmin.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Asmin.Core.Entities.Concrete;
using Asmin.Core.Extensions;
using Asmin.Core.Utilities.Hash;
using Asmin.Core.Utilities.Result;
using Asmin.DataAccess.Abstract;
using Asmin.Entities.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IResult> AddAsync(User user)
        {
            user.Password = _hashService.CreateHash(user.Password);

            var validationResult = _userValidator.Validate(user);

            if (!validationResult.IsValid)
            {
                var firstErrorMessage = validationResult.Errors.Select(failure => failure.ErrorMessage).FirstOrDefault();
                return new ErrorResult(firstErrorMessage);
            }

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

        public async Task<IDataResult<User>> Login(UserLoginDto user)
        {
            var hashedPassword = _hashService.CreateHash(user.Password);

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
