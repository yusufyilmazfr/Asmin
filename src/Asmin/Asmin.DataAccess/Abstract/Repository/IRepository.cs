using Asmin.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asmin.DataAccess.Abstract.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        List<T> GetList();
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetListAsync();
        Task<bool> AddAsnyc(T entity);
        Task<bool> UpdateAsnyc(T entity);
        Task<bool> RemoveAsnyc(T entity);
    }
}
