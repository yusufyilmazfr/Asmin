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
        Task<T> GetByIdAsync(int id);
        List<T> GetList();
        Task<List<T>> GetListAsync();
        T Add(T entity);
        Task<T> AddAsnyc(T entity);
        T Update(T entity);
        Task<T> UpdateAsnyc(T entity);
        T Remove(T entity);
        Task<T> RemoveAsnyc(T entity);
    }
}
