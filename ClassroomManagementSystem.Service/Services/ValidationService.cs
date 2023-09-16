using ClassroomManagementSystem.Core.Dtos;
using ClassroomManagementSystem.Core.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ClassroomManagementSystem.Service.Services
{
    public class ValidationService : IValidationService
    {
        public List<string> Errors { get; set; }

        public bool Validate<TDto, TValidator>(TDto dto) where TValidator : AbstractValidator<TDto>
        {
            var validator = Activator.CreateInstance<TValidator>();
            var validationResult = validator.Validate(dto);
            

            Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            
            if (!validationResult.IsValid)
            {

                return true;
            }
            return false;
        }
        public ResponseDto<NoContentDto> ReturnValidateError()
        {
            return ResponseDto<NoContentDto>.Fail(StatusCodes.Status400BadRequest, Errors);

        }
    }
}
