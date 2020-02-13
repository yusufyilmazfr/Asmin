using Asmin.Business.Abstract;
using Asmin.DataAccess.Abstract;
using Asmin.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Business.Concrete
{
    public class UserManager : IUserManager
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<User> GetList()
        {
            return _userDal.GetList();
        }
    }
}
