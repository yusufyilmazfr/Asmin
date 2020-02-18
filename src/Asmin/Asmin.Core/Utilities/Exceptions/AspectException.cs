using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Asmin.Core.Utilities.Exceptions
{
    public class AspectException : Exception
    {
        public AspectException() { }

        public AspectException(string message) : base(message) { }

        public AspectException(string message, Exception innerException) : base(message, innerException) { }

        public AspectException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
