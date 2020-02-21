using Asmin.Core.Utilities.Result;
using Asmin.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asmin.Business.Abstract
{
    public interface IIncomingVisitorManager
    {
        Task<IResult> AddAsync(IncomingVisitor incomingVisitor);
        Task<IDataResult<int>> GetCountAsync();
    }
}
