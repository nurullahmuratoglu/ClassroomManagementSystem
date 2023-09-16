using ClassroomManagementSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Repositories
{
    public interface IClassEntityRepository:IGenericRepository<ClassEntity>
    {
        Task<ClassEntity> GetClassEntityByIdWithLessonAsync(int id);
        Task<ClassEntity> GetClassEntityByIdWithStudentAsync(int id);
        
    }
}
