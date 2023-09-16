using ClassroomManagementSystem.Core.Dtos;
using ClassroomManagementSystem.Core.Dtos.StudentExamResult;
using ClassroomManagementSystem.Core.Dtos.Teacher;
using ClassroomManagementSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Services
{
    public interface IStudentExamResultService:IService<StudentExamResult, StudentExamResultDto>
    {
        Task<ResponseDto<NoContentDto>> AddAsync(StudentExamResultCreateDto dto);
        Task<ResponseDto<NoContentDto>> UpdateAsync(StudentExamResultUpdateDto dto);

    }
}
