using Asmin.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Business.Abstract
{
    public interface IUserManager
    {
        List<User> GetList();
    }
}
