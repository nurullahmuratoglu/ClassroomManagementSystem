using ClassroomManagementSystem.Core.Model;
using ClassroomManagementSystem.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Repository.Respositories
{
    public class ClassEntityRepository : GenericRepository<ClassEntity>, IClassEntityRepository
    {
        public ClassEntityRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ClassEntity> GetClassEntityByIdWithLessonAsync(int id)
        {

            var classEntity = await _context.ClassEntities.Include(x => x.Lessons.Where(y => y.IsDeleted == false)).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            return classEntity;
        }

        public async Task<ClassEntity> GetClassEntityByIdWithStudentAsync(int id)
        {
            var classEntity = await _context.ClassEntities.Include(x => x.Students.Where(y => y.IsDeleted == false)).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            return classEntity;
        }
    }
}
