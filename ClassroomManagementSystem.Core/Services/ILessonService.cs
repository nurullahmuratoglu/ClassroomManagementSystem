using ClassroomManagementSystem.Core.Dtos;
using ClassroomManagementSystem.Core.Dtos.Lesson;
using ClassroomManagementSystem.Core.Dtos.Student;
using ClassroomManagementSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Services
{
    public interface ILessonService:IService<Lesson,LessonDto>
    {



        //Task<ResponseDto<NoContentDto>> AddLessonWithClassEntity(LessonCreateWithClassEntityDto dto);
        Task<ResponseDto<List<LessonWithTeacherDto>>> GetLessonWithTeacher();
        Task<ResponseDto<NoContentDto>> AddAsync(LessonCreateDto dto);
        Task<ResponseDto<NoContentDto>> UpdateAsync(LessonUpdateDto dto);
    }
}
