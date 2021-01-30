using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asmin.Core.Utilities.Result;
using Asmin.Entities.Concrete;

namespace Asmin.WebMVC.Services.Rest.IncomingVisitorService
{
    public interface IIncomingVisitorApiService
    {
        Task<Result> AddAsync(IncomingVisitor incomingVisitor);
        Task<DataResult<int>> GetCountAsync();
    }
}
