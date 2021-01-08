using Asmin.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Entities.Concrete
{
    public class IncomingVisitor : BaseEntity<int>
    {
        public string IpAddress { get; set; }
    }
}
