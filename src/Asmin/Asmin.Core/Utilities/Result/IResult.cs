using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.Utilities.Result
{
    /// <summary>
    /// IResult provides base information for method status.
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// Check method done successfully.
        /// </summary>
        bool IsSuccess { get; }
        /// <summary>
        /// Result message.
        /// </summary>
        string Message { get; }
    }
}
