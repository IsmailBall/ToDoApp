using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Dal.Contexts;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.Dal.Repository
{
    public class WorkDal : EntityRepositoryBase<Work,WorkContext> , IWorkDal
    {
    }
}
