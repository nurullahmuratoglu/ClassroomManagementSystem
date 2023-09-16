using ClassroomManagementSystem.Core.Dtos;
using ClassroomManagementSystem.Core.Dtos.StudentExamResult;
using ClassroomManagementSystem.Core.Model;
using ClassroomManagementSystem.Core.Repositories;
using ClassroomManagementSystem.Core.Services;
using ClassroomManagementSystem.Core.UnitOfWorks;
using ClassroomManagementSystem.Service.Mapping;
using ClassroomManagementSystem.Service.Validations.StudentExamResult;
using Microsoft.AspNetCore.Http;

namespace ClassroomManagementSystem.Service.Services
{
    public class StudentExamResultService : Service<StudentExamResult, StudentExamResultDto>, IStudentExamResultService
    {
        private readonly IStudentExamResultRepository _studentExamResultRepository;
        private readonly IValidationService _validationService;
        public StudentExamResultService(IGenericRepository<StudentExamResult> genericRepository, IUnitOfWorks unitOfWorks, IStudentExamResultRepository studentExamResultRepository, IValidationService validationService) : base(genericRepository, unitOfWorks)
        {
            _studentExamResultRepository = studentExamResultRepository;
            _validationService = validationService;
        }

        public async Task<ResponseDto<NoContentDto>> AddAsync(StudentExamResultCreateDto dto)
        {
            var validatorResult = _validationService.Validate<StudentExamResultCreateDto, StudentExamResultCreateDtoValidator>(dto);
            if (validatorResult)
            {
                return _validationService.ReturnValidateError();
            }
            var newStudentExamResult = ObjectMapper.Mapper.Map<StudentExamResult>(dto);
            await _studentExamResultRepository.AddAsync(newStudentExamResult);
            await _unitOfWorks.CommitAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<NoContentDto>> UpdateAsync(StudentExamResultUpdateDto dto)
        {
            var validatorResult = _validationService.Validate<StudentExamResultUpdateDto, StudentExamResultUpdateDtoValidator>(dto);
            if (validatorResult)
            {
                return _validationService.ReturnValidateError();
            }


            if (!await AnyAsync(dto.Id))
            {
                return ResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "Id Not Found");
            }
            var updateStudentExamResult = ObjectMapper.Mapper.Map<StudentExamResult>(dto);
            _studentExamResultRepository.UpdateAsync(updateStudentExamResult);
            await _unitOfWorks.CommitAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }
    }
}
