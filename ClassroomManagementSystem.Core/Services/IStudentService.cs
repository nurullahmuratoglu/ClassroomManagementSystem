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
    public interface IStudentService:IService<Student,StudentDto>
    {
        Task<ResponseDto<List<StudentWithClassEntityDto>>> GetStudentWithClassEntity();
        Task<ResponseDto<List<StudentWithStudentExampResult>>> GetStudentWithStudentExamResult();

        Task<ResponseDto<NoContentDto>> AddAsync(StudentCreateDto dto);
        Task<ResponseDto<NoContentDto>> UpdateAsync(StudentUpdateDto dto);
    }
}
