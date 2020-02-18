using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Asmin.Core.Utilities.Exceptions
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException() { }

        public AuthorizationException(string message) : base(message) { }

        public AuthorizationException(string message, Exception innerException) : base(message, innerException) { }

        public AuthorizationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
