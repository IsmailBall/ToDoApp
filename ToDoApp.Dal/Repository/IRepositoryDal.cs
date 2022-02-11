using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Dal.Repository
{
    public interface IRepositoryDal <T>
    {
        Task Add(T entity);
        Task Remove(T entity);
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null, bool isTracking = false);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task Update(T entity);
        Task Update(T entity, T updatedEntity);
    }
}
