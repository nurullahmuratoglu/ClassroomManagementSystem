using ClassroomManagementSystem.Core.Dtos;
using ClassroomManagementSystem.Core.Dtos.Lesson;
using ClassroomManagementSystem.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public async Task<ResponseDto<IEnumerable<LessonDto>>> GetAll()
        {
            return await _lessonService.GetAllAsync();
        }
        [HttpPost]
        public async Task<ResponseDto<NoContentDto>> AddLesson(LessonCreateDto request)
        {
            return await _lessonService.AddAsync(request);

        }
        [HttpDelete("{id}")]
        public async Task<ResponseDto<NoContentDto>> Remove(int id)
        {
            return await _lessonService.RemoveAsync(id);

        }
        [HttpPut]
        public async Task<ResponseDto<NoContentDto>> Update(LessonUpdateDto request)
        {

            return await _lessonService.UpdateAsync(request);
        }
        [HttpGet("{id}")]
        public async Task<ResponseDto<LessonDto>> GetById(int id)
        {
            return await _lessonService.GetByIdAsync(id);

        }
        [HttpGet]
        [Route("LessonWithTeacher")]
        public async Task<ResponseDto<List<LessonWithTeacherDto>>> LessonWithTeacher() 
        {
            return await _lessonService.GetLessonWithTeacher();
        
        }
        
    }
}