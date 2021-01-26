using Asmin.Core.Entities.Concrete;
using Asmin.Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Asmin.Entities.CustomEntities.Request.User;
using Asmin.Entities.CustomEntities.Response.User;

namespace Asmin.Business.Abstract
{
    public interface IUserManager
    {
        /// <summary>
        /// Returns user login response if user exists.
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        IDataResult<UserLoginResponse> Login(UserLoginRequest loginRequest);
        /// <summary>
        /// Get user by specified id value.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IDataResult<User>> GetByIdAsync(int id);
        /// <summary>
        /// Get user list.
        /// </summary>
        /// <returns></returns>
        Task<IDataResult<List<User>>> GetListAsync();
        /// <summary>
        /// Insert new user to database.
        /// </summary>
        /// <param name="insertUserRequest"></param>
        /// <returns></returns>
        Task<IResult> AddAsync(InsertUserRequest insertUserRequest);
        /// <summary>
        /// Update user from database.
        /// </summary>
        /// <param name="updateUserRequest"></param>
        /// <returns></returns>
        Task<IResult> UpdateAsync(UpdateUserRequest updateUserRequest);
        /// <summary>
        /// Remove user from database.
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        Task<IResult> RemoveAsync(int id);
        /// <summary>
        /// Get claims of user.
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        IDataResult<List<OperationClaim>> GetClaimsByUserId(int id);
        /// <summary>
        /// It returns users count.
        /// </summary>
        /// <returns></returns>
        Task<IDataResult<int>> GetCountAsync();
    }
}
