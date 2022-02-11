using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Business.ValidationRules
{
    public interface IValidate<T>
    {
        bool ExecuteValidation(T Tentity);
    }
}
