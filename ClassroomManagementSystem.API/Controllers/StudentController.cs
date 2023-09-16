using ClassroomManagementSystem.Core.Dtos;
using ClassroomManagementSystem.Core.Dtos.Student;
using ClassroomManagementSystem.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<ResponseDto<IEnumerable<StudentDto>>> GetAll()
        {
            return await _studentService.GetAllAsync();
        }
        [HttpPost]
        public async Task<ResponseDto<NoContentDto>> AddStudent(StudentCreateDto request)
        {
            return await _studentService.AddAsync(request);

        }
        [HttpDelete("{id}")]
        public async Task<ResponseDto<NoContentDto>> Remove(int id)
        {
            return await _studentService.RemoveAsync(id);

        }
        [HttpPut]
        public async Task<ResponseDto<NoContentDto>> Update(StudentUpdateDto request)
        {

            return await _studentService.UpdateAsync(request);
        }
        [HttpGet("{id}")]
        public async Task<ResponseDto<StudentDto>> GetById(int id)
        {
            return await _studentService.GetByIdAsync(id);
        
        }
        [HttpGet]
        [Route("StudentWithClass")]
        public async Task<ResponseDto<List<StudentWithClassEntityDto>>> LessonWithTeacher()
        {
            return await _studentService.GetStudentWithClassEntity();

        }
        [HttpGet]
        [Route("StudentWithExamResult")]
        public async Task<ResponseDto<List<StudentWithStudentExampResult>>> GetStudentWithStudentExamResult()
        {
            return await _studentService.GetStudentWithStudentExamResult();

        }
    }
}
