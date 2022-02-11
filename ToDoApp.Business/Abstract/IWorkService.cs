using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Dal.Utilities.Results;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.Business.Abstract
{
    public interface IWorkService
    {
        Task<IResult> Add(Work work);
        Task<IDataResult<List<Work>>> GetAll(bool isTracking = false);
        Task<IDataResult<Work>> Get(int id);
        Task<IResult> Remove(Work work);
        Task<IResult> Update(Work work);
        Task<IResult> Update(Work work, Work updatedWork);
    }
}
