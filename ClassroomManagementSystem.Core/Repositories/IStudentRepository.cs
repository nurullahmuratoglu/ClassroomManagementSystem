using ClassroomManagementSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Repositories
{
    public interface IStudentRepository:IGenericRepository<Student>
    {
        Task<List<Student>> GetStudentWithClassEntity();
        Task<List<Student>> GetStudentWithStudentExamResult();
    }
}
