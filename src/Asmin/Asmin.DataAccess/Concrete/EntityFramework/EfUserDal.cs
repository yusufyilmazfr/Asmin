using Asmin.DataAccess.Abstract;
using Asmin.DataAccess.Concrete.EntityFramework.Context;
using Asmin.DataAccess.Concrete.EntityFramework.Repository;
using Asmin.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfRepositoryBase<User, AsminDbContext>, IUserDal
    {

    }
}
