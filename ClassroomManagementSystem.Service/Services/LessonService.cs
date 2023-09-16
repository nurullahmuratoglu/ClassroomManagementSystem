using ClassroomManagementSystem.Core.Dtos;
using ClassroomManagementSystem.Core.Dtos.Lesson;
using ClassroomManagementSystem.Core.Model;
using ClassroomManagementSystem.Core.Repositories;
using ClassroomManagementSystem.Core.Services;
using ClassroomManagementSystem.Core.UnitOfWorks;
using ClassroomManagementSystem.Service.Mapping;
using ClassroomManagementSystem.Service.Validations.Lesson;
using Microsoft.AspNetCore.Http;

namespace ClassroomManagementSystem.Service.Services
{
    public class LessonService : Service<Lesson, LessonDto>, ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IClassEntityRepository _classEntityRepository;
        private readonly IValidationService _validationService;
        public LessonService(IGenericRepository<Lesson> genericRepository, IUnitOfWorks unitOfWorks, ILessonRepository lessonRepository, IClassEntityRepository classEntityRepository, IValidationService validationService) : base(genericRepository, unitOfWorks)
        {
            _lessonRepository = lessonRepository;
            _classEntityRepository = classEntityRepository;
            _validationService = validationService;
        }

        public async Task<ResponseDto<NoContentDto>> AddAsync(LessonCreateDto dto)
        {
            var validatorResult = _validationService.Validate<LessonCreateDto, LessonCreateDtoValidator>(dto);
            if (validatorResult)
            {
                return _validationService.ReturnValidateError();
            }


            var newLesson = ObjectMapper.Mapper.Map<Lesson>(dto);
            var classEntities = await _classEntityRepository.GetSelectedEntitiesAsync(dto.ClassEntitiesId);

            newLesson.ClassEntities = classEntities;
            await _lessonRepository.AddAsync(newLesson);
            await _unitOfWorks.CommitAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }
        public async Task<ResponseDto<List<LessonWithTeacherDto>>> GetLessonWithTeacher()
        {
            var lesson = await _lessonRepository.GetLessonWithTeacher();
            var lessondto = ObjectMapper.Mapper.Map<List<LessonWithTeacherDto>>(lesson);
            return ResponseDto<List<LessonWithTeacherDto>>.Success(StatusCodes.Status200OK, lessondto);
        }

        public async Task<ResponseDto<NoContentDto>> UpdateAsync(LessonUpdateDto dto)
        {
            var validatorResult = _validationService.Validate<LessonUpdateDto, LessonUpdateDtoValidator>(dto);
            if (validatorResult)
            {
                return _validationService.ReturnValidateError();
            }



            if (!await AnyAsync(dto.Id))
            {
                return ResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "Id Not Found");
            }
            var lessonToUpdate = await _lessonRepository.GetLessonByIdWithClassEntityAsync(dto.Id);

            
            lessonToUpdate.ClassEntities.Clear();

            var classentityToAdd = await _classEntityRepository.GetSelectedEntitiesAsync(dto.ClassEntityId);
            lessonToUpdate.Name = dto.Name;

            foreach (var classEntity in classentityToAdd)
            {
                lessonToUpdate.ClassEntities.Add(classEntity);
            }
            await _unitOfWorks.CommitAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }

    }
}
