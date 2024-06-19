using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.Utilities.Result
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool isSuccess) : base(isSuccess)
        {
            Data = data;
        }

        public DataResult(T data, bool isSuccess, string message) : base(isSuccess, message)
        {
            Data = data;
        }

        public DataResult()
        {

        }

        public T Data { get; set; }
    }
}
