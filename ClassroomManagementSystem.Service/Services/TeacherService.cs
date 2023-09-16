using ClassroomManagementSystem.Core.Dtos;
using ClassroomManagementSystem.Core.Dtos.Teacher;
using ClassroomManagementSystem.Core.Model;
using ClassroomManagementSystem.Core.Repositories;
using ClassroomManagementSystem.Core.Services;
using ClassroomManagementSystem.Core.UnitOfWorks;
using ClassroomManagementSystem.Service.Mapping;
using ClassroomManagementSystem.Service.Validations.Teacher;
using Microsoft.AspNetCore.Http;

namespace ClassroomManagementSystem.Service.Services
{
    public class TeacherService : Service<Teacher, TeacherDto>, ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IValidationService _validationService;
        public TeacherService(IGenericRepository<Teacher> genericRepository, IUnitOfWorks unitOfWorks, ITeacherRepository teacherRepository, IValidationService validationService) : base(genericRepository, unitOfWorks)
        {
            _teacherRepository = teacherRepository;
            _validationService = validationService;
        }

        public async Task<ResponseDto<NoContentDto>> AddAsync(TeacherCreateDto dto)
        {
            var validatorResult = _validationService.Validate<TeacherCreateDto, TeacherCreateDtoValidator>(dto);
            if (validatorResult)
            {
                return _validationService.ReturnValidateError();
            }

            var newTeacher = ObjectMapper.Mapper.Map<Teacher>(dto);
            await _teacherRepository.AddAsync(newTeacher);
            await _unitOfWorks.CommitAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<NoContentDto>> UpdateAsync(TeacherUpdateDto dto)
        {
            var validatorResult = _validationService.Validate<TeacherUpdateDto, TeacherUpdateDtoValidator>(dto);
            if (validatorResult)
            {
                return _validationService.ReturnValidateError();
            }


            if (!await AnyAsync(dto.Id))
            {
                return ResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "Id Not Found");
            }
            var updateTeacher = ObjectMapper.Mapper.Map<Teacher>(dto);
            _teacherRepository.UpdateAsync(updateTeacher);
            await _unitOfWorks.CommitAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }
    }
}
