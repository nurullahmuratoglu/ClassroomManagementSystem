using ClassroomManagementSystem.Core.Dtos;
using ClassroomManagementSystem.Core.Dtos.StudentExamResult;
using ClassroomManagementSystem.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentExamResultController : ControllerBase
    {
        private readonly IStudentExamResultService _studentExamResultService;

        public StudentExamResultController(IStudentExamResultService studentExamResultService)
        {
            _studentExamResultService = studentExamResultService;
        }

        [HttpGet]
        public async Task<ResponseDto<IEnumerable<StudentExamResultDto>>> GetAll()
        {
            return await _studentExamResultService.GetAllAsync();
        }
        [HttpPost]
        public async Task<ResponseDto<NoContentDto>> AddLesson(StudentExamResultCreateDto request)
        {
            return await _studentExamResultService.AddAsync(request);

        }
        [HttpDelete("{id}")]
        public async Task<ResponseDto<NoContentDto>> Remove(int id)
        {
            return await _studentExamResultService.RemoveAsync(id);

        }
        [HttpPut]
        public async Task<ResponseDto<NoContentDto>> Update(StudentExamResultUpdateDto request)
        {

            return await _studentExamResultService.UpdateAsync(request);
        }
        [HttpGet("{id}")]
        public async Task<ResponseDto<StudentExamResultDto>> GetById(int id)
        {
            return await _studentExamResultService.GetByIdAsync(id);

        }
    }
}
