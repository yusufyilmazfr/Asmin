using Asmin.Core.Entities.Concrete;
using Asmin.DataAccess.Abstract.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.DataAccess.Abstract
{
    /// <summary>
    /// User repository interface.
    /// </summary>
    public interface IUserDal : IRepository<User, int>
    {
        /// <summary>
        /// Method returns claims of specified user.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <returns></returns>
        List<OperationClaim> GetClaimsByUserId(int id);

        /// <summary>
        /// Returns user by email and password.
        /// </summary>
        /// <param name="email">Email.</param>
        /// <param name="password">Hashed password.</param>
        /// <returns></returns>
        User GetUser(string email, string password);
    }
}
