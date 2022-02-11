using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Dal.Utilities.Results
{
    public class ErrorDataResult <T> : DataResult<T>
    {
        public ErrorDataResult(string message) : base(default, message,false)
        {

        }
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
