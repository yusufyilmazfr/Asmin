using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string IPAddress { get; set; }
        public string MethodName { get; set; }
        public List<LogParameter> LogParameters { get; set; }
    }
}
