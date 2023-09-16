using ClassroomManagementSystem.Core.Dtos.ClassEntity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Service.Validations.ClassEntity
{
    public class ClassEntityCreateDtoValidator : AbstractValidator<ClassEntityCreateDto>
    {
        public ClassEntityCreateDtoValidator()
        {
            RuleFor(dto => dto.Name)
                     .NotEmpty().WithMessage("İsim alanı boş olamaz.")
                     .MaximumLength(50).WithMessage("İsim alanı en fazla 50 karakter olmalıdır.");
        }
    }
}
