using ClassroomManagementSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        void UpdateAsync(T entity);
        void Remove(T entity);
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();
        Task<bool> AnyAsync(int id);
        Task<List<T>> GetSelectedEntitiesAsync(IEnumerable<int> selectedIds);
    }
}
