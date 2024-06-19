using Asmin.DataAccess.Abstract.Repository;
using Asmin.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.DataAccess.Abstract
{
    /// <summary>
    /// Incoming visitor repository interface.
    /// </summary>
    public interface IIncomingVisitorDal : IRepository<IncomingVisitor, int>
    {

    }
}
