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
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Student>> GetStudentWithClassEntity()
        {

            return await _context.Students.Where(x=>x.IsDeleted==false).Include(x => x.ClassEntity).ToListAsync();
        }

        public async Task<List<Student>> GetStudentWithStudentExamResult()
        {
            return await _context.Students.Where(x=>x.IsDeleted==false).Include(x => x.StudentExamResults).ToListAsync();
        }
    }
}
