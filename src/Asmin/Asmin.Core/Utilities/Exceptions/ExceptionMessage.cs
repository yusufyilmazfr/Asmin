using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.Utilities.Exceptions
{
    class ExceptionMessage
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ExceptionMessage(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
