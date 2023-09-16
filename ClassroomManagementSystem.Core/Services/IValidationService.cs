using ClassroomManagementSystem.Core.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Services
{
    public interface IValidationService
    {
        bool Validate<TDto, TValidator>(TDto dto) where TValidator : AbstractValidator<TDto>;
        ResponseDto<NoContentDto> ReturnValidateError();
    }
}
