using ClassroomManagementSystem.Core.Model;
using ClassroomManagementSystem.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Repository.Respositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _dbSet.Where(x => x.IsDeleted == false && x.Id == id).AnyAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.Where(x => x.IsDeleted == false).AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            entity.IsDeleted = true;
        }

        public void UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }
        public async Task<List<T>> GetSelectedEntitiesAsync(IEnumerable<int> selectedIds)
        {

            return await _dbSet.Where(entity => selectedIds.Contains(entity.Id)).ToListAsync();
        }
    }
}