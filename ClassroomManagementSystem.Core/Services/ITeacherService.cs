using ClassroomManagementSystem.Core.Dtos.Student;
using ClassroomManagementSystem.Core.Dtos;
using ClassroomManagementSystem.Core.Dtos.Teacher;
using ClassroomManagementSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Services
{
    public interface ITeacherService:IService<Teacher,TeacherDto>
    {
        Task<ResponseDto<NoContentDto>> AddAsync(TeacherCreateDto dto);
        Task<ResponseDto<NoContentDto>> UpdateAsync(TeacherUpdateDto dto);
    }
}
