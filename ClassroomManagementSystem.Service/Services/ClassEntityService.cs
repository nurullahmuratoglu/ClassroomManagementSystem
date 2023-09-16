using ClassroomManagementSystem.Core.Dtos;
using ClassroomManagementSystem.Core.Dtos.ClassEntity;
using ClassroomManagementSystem.Core.Model;
using ClassroomManagementSystem.Core.Repositories;
using ClassroomManagementSystem.Core.Services;
using ClassroomManagementSystem.Core.UnitOfWorks;
using ClassroomManagementSystem.Service.Mapping;
using ClassroomManagementSystem.Service.Validations.ClassEntity;
using Microsoft.AspNetCore.Http;

namespace ClassroomManagementSystem.Service.Services
{
    public class ClassEntityService : Service<ClassEntity, ClassEntityDto>, IClassEntityService
    {
        private readonly IClassEntityRepository _classEntityRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IValidationService _validationService;
        public ClassEntityService(IGenericRepository<ClassEntity> genericRepository, IUnitOfWorks unitOfWorks, IClassEntityRepository classEntityRepository, ILessonRepository lessonRepository, IValidationService validationService) : base(genericRepository, unitOfWorks)
        {
            _classEntityRepository = classEntityRepository;
            _lessonRepository = lessonRepository;
            _validationService = validationService;
        }

        public async Task<ResponseDto<NoContentDto>> AddAsync(ClassEntityCreateDto dto)
        {
            var validatorResult = _validationService.Validate<ClassEntityCreateDto, ClassEntityCreateDtoValidator>(dto);
            if (validatorResult)
            {
               return _validationService.ReturnValidateError();
            }
            var newClassEntity = ObjectMapper.Mapper.Map<ClassEntity>(dto);
            await _classEntityRepository.AddAsync(newClassEntity);
            await _unitOfWorks.CommitAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<ClassEntityWithLessonDto>> GetClassEntityByIdWithLesson(int id)
        {
            if (!await AnyAsync(id))
            {
                return ResponseDto<ClassEntityWithLessonDto>.Fail(StatusCodes.Status404NotFound, "Id Not Found");
            }
            var entites = await _classEntityRepository.GetClassEntityByIdWithLessonAsync(id);
            var dtos = ObjectMapper.Mapper.Map<ClassEntityWithLessonDto>(entites);
            return ResponseDto<ClassEntityWithLessonDto>.Success(StatusCodes.Status200OK, dtos);
        }

        public async Task<ResponseDto<ClassEntityWithStudentDto>> GetClassEntityByIdWithStudentAsync(int id)
        {
            if (!await AnyAsync(id))
            {
                return ResponseDto<ClassEntityWithStudentDto>.Fail(StatusCodes.Status404NotFound, "Id Not Found");
            }
            var entites = await _classEntityRepository.GetClassEntityByIdWithStudentAsync(id);
            var dtos = ObjectMapper.Mapper.Map<ClassEntityWithStudentDto>(entites);
            return ResponseDto<ClassEntityWithStudentDto>.Success(StatusCodes.Status200OK, dtos);
        }

        public async Task<ResponseDto<NoContentDto>> UpdateAsync(ClassEntityUpdateDto dto)
        {
            var validatorResult = _validationService.Validate<ClassEntityUpdateDto, ClassEntityUpdateDtoValidator>(dto);
            if (validatorResult)
            {
                return _validationService.ReturnValidateError();
            }


            if (!await AnyAsync(dto.Id))
            {
                return ResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "Id Not Found");
            }

            var classEntityToUpdate = await _classEntityRepository.GetClassEntityByIdWithLessonAsync(dto.Id);


            classEntityToUpdate.Lessons.Clear();
            var lessonsToAdd = await _lessonRepository.GetSelectedEntitiesAsync(dto.LessonId);
            classEntityToUpdate.Name = dto.Name;

            foreach (var lesson in lessonsToAdd)
            {
                classEntityToUpdate.Lessons.Add(lesson);
            }
            await _unitOfWorks.CommitAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }
    }
}
