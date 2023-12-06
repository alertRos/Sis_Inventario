using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.Interface.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync (T entity);
        Task<T> UpdateAsync (T entity);
        Task<T> DeleteAsync (T entity);

        Task<T> GetByIdAsync (int id);
        Task<IEnumerable<T>> GetAllAsync ();
        Task<IEnumerable<T>> GetAllWithIncludesAsync(List<string> includes);
    }
}
