using Asmin.DataAccess.Abstract;
using Asmin.DataAccess.Concrete.EntityFramework.Context;
using Asmin.DataAccess.Concrete.EntityFramework.Repository;
using Asmin.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Asmin.Core.Configuration.Context;

namespace Asmin.DataAccess.Concrete.EntityFramework
{
    public class EfIncomingVisitorDal : EfRepositoryBase<IncomingVisitor, int>, IIncomingVisitorDal
    {
        private readonly IAsminConfigurationContext _asminConfigurationContext;

        public EfIncomingVisitorDal(IAsminConfigurationContext asminConfigurationContext) : base(asminConfigurationContext.ConnectionString)
        {
            _asminConfigurationContext = asminConfigurationContext;
        }
    }
}
