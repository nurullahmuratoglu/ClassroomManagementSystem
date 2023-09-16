using ClassroomManagementSystem.Core.Dtos;
using ClassroomManagementSystem.Core.Dtos.ClassEntity;
using ClassroomManagementSystem.Core.Dtos.Student;
using ClassroomManagementSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Services
{
    public interface IClassEntityService:IService<ClassEntity, ClassEntityDto>
    {
        Task<ResponseDto<ClassEntityWithLessonDto>> GetClassEntityByIdWithLesson(int id);
        Task<ResponseDto<ClassEntityWithStudentDto>> GetClassEntityByIdWithStudentAsync(int id);
        Task<ResponseDto<NoContentDto>> AddAsync(ClassEntityCreateDto dto);
        Task<ResponseDto<NoContentDto>> UpdateAsync(ClassEntityUpdateDto dto);

    }
}
