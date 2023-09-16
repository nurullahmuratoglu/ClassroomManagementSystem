using ClassroomManagementSystem.Core.Dtos.Lesson;
using ClassroomManagementSystem.Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassroomManagementSystem.Core.Services;
using ClassroomManagementSystem.Core.Dtos.Teacher;

namespace ClassroomManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<ResponseDto<IEnumerable<TeacherDto>>> GetAll()
        {
            return await _teacherService.GetAllAsync();
        }
        [HttpPost]
        public async Task<ResponseDto<NoContentDto>> AddTeacher(TeacherCreateDto request)
        {
            return await _teacherService.AddAsync(request);

        }
        [HttpDelete("{id}")]
        public async Task<ResponseDto<NoContentDto>> Remove(int id)
        {
            return await _teacherService.RemoveAsync(id);

        }
        [HttpPut]
        public async Task<ResponseDto<NoContentDto>> Update(TeacherUpdateDto request)
        {

            return await _teacherService.UpdateAsync(request);
        }
        [HttpGet("{id}")]
        public async Task<ResponseDto<TeacherDto>> GetById(int id)
        {
            return await _teacherService.GetByIdAsync(id);

        }
    }
}
