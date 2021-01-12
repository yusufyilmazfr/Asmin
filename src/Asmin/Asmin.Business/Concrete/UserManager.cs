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
using System.Security.Claims;
using System.Threading.Tasks;
using Asmin.Entities.CustomEntities.Request.User;
using Asmin.Entities.CustomEntities.Response.User;
using Asmin.Packages.AOP.Aspects.Exception;
using Asmin.Packages.AOP.Aspects.Transaction;
using Asmin.Packages.Hashing.Core.Service;
using Asmin.Packages.JWT.Service;

namespace Asmin.Business.Concrete
{
    public class UserManager : IUserManager
    {
        private readonly IUserDal _userDal;
        private readonly IHashService _hashService;
        private readonly ITokenService _tokenService;
        private readonly IValidator<User> _userValidator;

        public UserManager(IUserDal userDal, IValidator<User> userValidator, IHashService hashService, ITokenService tokenService)
        {
            _userDal = userDal;
            _hashService = hashService;
            _tokenService = tokenService;
            _userValidator = userValidator;
        }

        [AsminExceptionAspect]
        [AsminUnitOfWorkAspect]
        public async Task<IResult> AddAsync(InsertUserRequest insertUserRequest)
        {
            var user = new User
            {
                FirstName = insertUserRequest.FirstName,
                LastName = insertUserRequest.LastName,
                Email = insertUserRequest.Email,
                Password = insertUserRequest.Password
            };

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

        public async Task<IResult> RemoveAsync(int id)
        {
            var currentUser = await _userDal.GetByIdAsync(id);

            if (currentUser == null)
            {
                return new ErrorResult(ResultMessages.UserNotFound);
            }

            await _userDal.RemoveAsync(currentUser);

            return new SuccessResult(ResultMessages.UserRemoved);
        }

        public async Task<IResult> UpdateAsync(UpdateUserRequest updateUserRequest)
        {
            var currentUser = await _userDal.GetByIdAsync(updateUserRequest.Id);

            if (currentUser == null)
            {
                return new ErrorResult(ResultMessages.UserNotFound);
            }

            currentUser.FirstName = updateUserRequest.FirstName;
            currentUser.LastName = updateUserRequest.LastName;
            currentUser.Email = updateUserRequest.Email;

            await _userDal.UpdateAsync(currentUser);

            return new SuccessResult(ResultMessages.UserUpdated);
        }

        public IDataResult<UserLoginResponse> Login(UserLoginRequest loginRequest)
        {
            var userLoginResponse = new UserLoginResponse();

            var hashedPassword = _hashService.Generate(loginRequest.Password);

            var user = _userDal.GetUser(loginRequest.Email, hashedPassword);

            if (user == null)
            {
                return new ErrorDataResult<UserLoginResponse>(userLoginResponse, ResultMessages.UserNotFound);
            }

            userLoginResponse.User = user;
            userLoginResponse.TokenInformation = _tokenService.Generate(GenerateUserClaims(user));

            return new SuccessDataResult<UserLoginResponse>(userLoginResponse);
        }

        private IEnumerable<Claim> GenerateUserClaims(User user)
        {
            return new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.FirstName),
                new Claim(ClaimTypes.Surname,user.LastName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            };
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
