using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Dal.Repository
{
    public class EntityRepositoryBase<TEntity,TContext> : IRepositoryDal<TEntity>
        where TEntity : class , new()
        where TContext : DbContext , new()
    {
        public async Task Add(TEntity entity)
        {
            await using (TContext context = new TContext())
            {
                var entityState = context.Set<TEntity>().Add(entity);
                entityState.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            await using (TContext context = new TContext())
            {
                var entity = context.Set<TEntity>().FirstOrDefault(filter);
                return entity;
            }
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null, bool isTracking = false)
        {
            await using (TContext context = new TContext())
            {
                if (isTracking)
                {
                    return filter != null ? context.Set<TEntity>().Where(filter).ToList() :
                        context.Set<TEntity>().ToList();
                }

                return filter != null ? context.Set<TEntity>().AsNoTracking().Where(filter).ToList() :
                        context.Set<TEntity>().AsNoTracking().ToList();
            }
        }

        public async Task Remove(TEntity entity)
        {
            await using (TContext context = new TContext())
            {
                var entityState = context.Set<TEntity>().Remove(entity);
                entityState.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public async Task Update(TEntity entity)
        {
            await using (TContext context = new TContext())
            {
                var entityState = context.Set<TEntity>().Update(entity);
                entityState.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public async Task Update(TEntity entity, TEntity updatedEntity)
        {
            await using (TContext context = new TContext())
            {
                context.Entry(entity).CurrentValues.SetValues(updatedEntity);
                context.SaveChanges();
            }
        }
    }
}
