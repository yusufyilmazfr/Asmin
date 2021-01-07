﻿using Asmin.Core.Entities.Concrete;
using Asmin.DataAccess.Abstract.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Asmin.DataAccess.Concrete.EntityFramework.Repository
{
    /// <summary>
    /// Generic repository base.
    /// </summary>
    /// <typeparam name="TEntity">TEntity is database entity.</typeparam>
    /// <typeparam name="TKey">Unique key of TEntity.</typeparam>
    /// <typeparam name="TContext">TContext is DbContext.</typeparam>
    public class EfRepositoryBase<TEntity, TKey, TContext> : IRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TContext : DbContext, new()
    {
        public bool Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                entity.CreatedDate = DateTime.Now;
                entity.ModifiedDate = DateTime.Now;

                context.Attach(entity).State = EntityState.Added;
                return context.SaveChanges() > 0;
            }
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                entity.CreatedDate = DateTime.Now;
                entity.ModifiedDate = DateTime.Now;

                context.Attach(entity).State = EntityState.Added;

                return await context.SaveChangesAsync() > 0;
            }
        }

        public TEntity GetById(TKey id)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(entity => entity.Id.Equals(id));
            }
        }

        public Task<TEntity> GetByIdAsync(TKey id)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id.Equals(id));
            }
        }

        public int GetCount()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Count();
            }
        }

        public Task<int> GetCountAsync()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().CountAsync();
            }
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
            using (var context = new TContext())
            {
                return context.Set<TEntity>().ToListAsync();
            }
        }

        public bool Remove(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Attach(entity).State = EntityState.Deleted;
                return context.SaveChanges() > 0;
            }
        }

        public async Task<bool> RemoveAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Attach(entity).State = EntityState.Deleted;
                return await context.SaveChangesAsync() > 0;
            }
        }

        public bool Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                entity.ModifiedDate = DateTime.Now;

                context.Attach(entity).State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                entity.ModifiedDate = DateTime.Now;

                context.Attach(entity).State = EntityState.Modified;

                return await context.SaveChangesAsync() > 0;
            }
        }
    }
}
