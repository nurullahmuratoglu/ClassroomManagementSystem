using ClassroomManagementSystem.Core.Dtos;
using ClassroomManagementSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Repositories
{
    public interface ILessonRepository:IGenericRepository<Lesson>
    {
        Task<Lesson> GetLessonByIdWithClassEntityAsync(int id);
        Task<List<Lesson>> GetLessonWithTeacher();
        
    }
}
