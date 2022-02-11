using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.Dal.Repository
{
    interface IWorkDal : IRepositoryDal<Work>
    {
    }
}
