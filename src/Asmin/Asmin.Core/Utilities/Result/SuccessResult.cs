using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.Utilities.Result
{
    /// <summary>
    /// Success result for successfully done method.
    /// </summary>
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true)
        {

        }

        public SuccessResult(string message) : base(true, message)
        {

        }
    }
}
