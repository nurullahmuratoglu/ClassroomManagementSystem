using ClassroomManagementSystem.Core.Dtos;
using ClassroomManagementSystem.Core.Dtos.ClassEntity;
using ClassroomManagementSystem.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassEntityController : ControllerBase
    {
        private readonly IClassEntityService _classEntityService;

        public ClassEntityController(IClassEntityService classEntityService)
        {
            _classEntityService = classEntityService;
        }

        [HttpGet]
        public async Task<ResponseDto<IEnumerable<ClassEntityDto>>> GetAll()
        {
            return await _classEntityService.GetAllAsync();
        }
        [HttpPost]
        public async Task<ResponseDto<NoContentDto>> AddStudent(ClassEntityCreateDto request)
        {
            return await _classEntityService.AddAsync(request);

        }
        [HttpDelete("{id}")]
        public async Task<ResponseDto<NoContentDto>> Remove(int id)
        {
            return await _classEntityService.RemoveAsync(id);

        }
        [HttpPut]
        public async Task<ResponseDto<NoContentDto>> Update(ClassEntityUpdateDto request)
        {

            return await _classEntityService.UpdateAsync(request);
        }
        [HttpGet("{id}")]
        public async Task<ResponseDto<ClassEntityDto>> GetById(int id)
        {
            return await _classEntityService.GetByIdAsync(id);

        }

        [HttpGet("[action]/{id}")]
        public async Task<ResponseDto<ClassEntityWithLessonDto>> GetClassEntityByIdWithLesson(int id)
        {
            return await _classEntityService.GetClassEntityByIdWithLesson(id);
        }
        [HttpGet("GetClassWithStudent/{id}")]
        public async Task<ResponseDto<ClassEntityWithStudentDto>> GetClassEntityByIdWithStudent(int id)
        {
            return await _classEntityService.GetClassEntityByIdWithStudentAsync(id);
        }
    }
}
