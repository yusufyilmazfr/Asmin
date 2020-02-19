using Asmin.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.Extensions
{
    public static class UserExtensions
    {
        public static User WithoutPassword(this User user)
        {
            user.Password = null;
            return user;
        }
    }
}
