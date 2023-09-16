using ClassroomManagementSystem.Core.Dtos;
using ClassroomManagementSystem.Core.Dtos.Student;
using ClassroomManagementSystem.Core.Model;
using ClassroomManagementSystem.Core.Repositories;
using ClassroomManagementSystem.Core.Services;
using ClassroomManagementSystem.Core.UnitOfWorks;
using ClassroomManagementSystem.Service.Mapping;
using ClassroomManagementSystem.Service.Validations.Student;
using Microsoft.AspNetCore.Http;

namespace ClassroomManagementSystem.Service.Services
{
    public class StudentService : Service<Student, StudentDto>, IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IValidationService _validationService;
        public StudentService(IGenericRepository<Student> genericRepository, IUnitOfWorks unitOfWorks, IStudentRepository studentRepository, IValidationService validationService) : base(genericRepository, unitOfWorks)
        {
            _studentRepository = studentRepository;
            _validationService = validationService;
        }

        public async Task<ResponseDto<NoContentDto>> AddAsync(StudentCreateDto dto)
        {
            var validatorResult = _validationService.Validate<StudentCreateDto, StudentCreateDtoValidator>(dto);
            if (validatorResult)
            {
                return _validationService.ReturnValidateError();
            }

            var newStudent = ObjectMapper.Mapper.Map<Student>(dto);
            await _studentRepository.AddAsync(newStudent);
            await _unitOfWorks.CommitAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<List<StudentWithClassEntityDto>>> GetStudentWithClassEntity()
        {
            var student = await _studentRepository.GetStudentWithClassEntity();
            var studentdto = ObjectMapper.Mapper.Map<List<StudentWithClassEntityDto>>(student);
            return ResponseDto<List<StudentWithClassEntityDto>>.Success(StatusCodes.Status200OK, studentdto);
        }

        public async Task<ResponseDto<List<StudentWithStudentExampResult>>> GetStudentWithStudentExamResult()
        {
            var student = await _studentRepository.GetStudentWithStudentExamResult();
            var studentdto = ObjectMapper.Mapper.Map<List<StudentWithStudentExampResult>>(student);
            return ResponseDto<List<StudentWithStudentExampResult>>.Success(StatusCodes.Status200OK, studentdto);
        }

        public async Task<ResponseDto<NoContentDto>> UpdateAsync(StudentUpdateDto dto)
        {
            var validatorResult = _validationService.Validate<StudentUpdateDto, StudentUpdateDtoValidator>(dto);
            if (validatorResult)
            {
                return _validationService.ReturnValidateError();
            }


            if (!await AnyAsync(dto.Id))
            {
                return ResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "Id Not Found");
            }
            var updateStudent = ObjectMapper.Mapper.Map<Student>(dto);
            _studentRepository.UpdateAsync(updateStudent);
            await _unitOfWorks.CommitAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }


    }
}
