using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.Utilities.Result
{
    /// <summary>
    /// Success data result for successfully done method.
    /// </summary>
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data) : base(data, true)
        {

        }

        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }
    }
}
