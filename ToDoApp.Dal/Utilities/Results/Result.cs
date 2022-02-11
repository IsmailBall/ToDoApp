using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Dal.Utilities.Results
{
    public class Result : IResult
    {
        public Result(string message, bool isSucceed)
        {
            Message = message;
            IsSucceed = isSucceed;
        }
        public Result(bool isSucceed)
        {
            IsSucceed = isSucceed;
        }

        public string Message { get;  }

        public bool IsSucceed { get; }
    }
}
