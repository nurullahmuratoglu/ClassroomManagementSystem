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
    public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Lesson> GetLessonByIdWithClassEntityAsync(int id)
        {
            var lesson = await _context.Lessons.Include(x => x.ClassEntities.Where(y=>y.IsDeleted==false)).FirstOrDefaultAsync(x => x.Id == id&&x.IsDeleted==false);
            return lesson;
        }

        public async Task<List<Lesson>> GetLessonWithTeacher()
        {

            var lesson= await _context.Lessons.Include(x => x.Teacher).Where(x => x.IsDeleted == false).ToListAsync();

            return lesson;
        }
    }
}
