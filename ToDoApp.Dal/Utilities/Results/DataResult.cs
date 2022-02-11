using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Dal.Utilities.Results
{
    public class DataResult<T> : Result,  IDataResult<T> 
    {
        public DataResult(T data, string message, bool isSucceed) : base(message, isSucceed)
        {
            Data = data;
        }
        public DataResult(T data,bool isSucceed) : base(isSucceed)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
