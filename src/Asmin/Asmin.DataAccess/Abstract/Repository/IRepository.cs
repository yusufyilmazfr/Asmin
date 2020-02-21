using Asmin.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Asmin.DataAccess.Abstract.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        T GetById(int id);
        List<T> GetList();
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        int GetCount();
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetListAsync();
        Task<bool> AddAsnyc(T entity);
        Task<bool> UpdateAsnyc(T entity);
        Task<bool> RemoveAsnyc(T entity);
        Task<int> GetCountAsync();
    }
}
