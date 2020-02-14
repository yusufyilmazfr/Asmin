using Asmin.DataAccess.Abstract.Repository;
using Asmin.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asmin.DataAccess.Concrete.EntityFramework.Repository
{
    public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext, new()
    {
        public bool Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Attach(entity).State = EntityState.Added;
                return context.SaveChanges() > 0;
            }
        }

        public Task<bool> AddAsnyc(TEntity entity)
        {
            return Task.Run(() => { return Add(entity); });
        }

        public TEntity GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(i => i.Id == id);
            }
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return Task.Run(() => { return GetById(id); });
        }

        public List<TEntity> GetList()
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public Task<List<TEntity>> GetListAsync()
        {
            return Task.Run(() => { return GetList(); });
        }

        public bool Remove(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Attach(entity).State = EntityState.Deleted;
                return context.SaveChanges() > 0;
            }
        }

        public Task<bool> RemoveAsnyc(TEntity entity)
        {
            return Task.Run(() => { return Remove(entity); });
        }

        public bool Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Attach(entity).State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
        }

        public Task<bool> UpdateAsnyc(TEntity entity)
        {
            return Task.Run(() => { return Update(entity); });
        }
    }
}
