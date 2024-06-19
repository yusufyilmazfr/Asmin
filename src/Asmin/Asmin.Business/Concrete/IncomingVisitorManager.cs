using Asmin.Business.Abstract;
using Asmin.Core.Constants.Messages;
using Asmin.Core.Utilities.Result;
using Asmin.DataAccess.Abstract;
using Asmin.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asmin.Business.Concrete
{
    public class IncomingVisitorManager : IIncomingVisitorManager
    {
        private readonly IIncomingVisitorDal _incomingVisitorDal;

        public IncomingVisitorManager(IIncomingVisitorDal incomingVisitorDal)
        {
            _incomingVisitorDal = incomingVisitorDal;
        }

        public async Task<IResult> AddAsync(IncomingVisitor incomingVisitor)
        {
            await _incomingVisitorDal.AddAsync(incomingVisitor);
            return new SuccessResult(ResultMessages.IncomingVisitorAdded);
        }

        public async Task<IDataResult<int>> GetCountAsync()
        {
            var visitorsCount = await _incomingVisitorDal.GetCountAsync();
            return new SuccessDataResult<int>(visitorsCount);
        }
    }
}
