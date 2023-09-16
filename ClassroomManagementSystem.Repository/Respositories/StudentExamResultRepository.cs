using ClassroomManagementSystem.Core.Model;
using ClassroomManagementSystem.Core.Repositories;
using ClassroomManagementSystem.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Repository.Respositories
{
    public class StudentExamResultRepository : GenericRepository<StudentExamResult>, IStudentExamResultRepository
    {
        public StudentExamResultRepository(AppDbContext context) : base(context)
        {
        }
    }
}
