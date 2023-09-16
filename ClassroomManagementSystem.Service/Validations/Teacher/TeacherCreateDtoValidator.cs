using ClassroomManagementSystem.Core.Dtos.Teacher;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Service.Validations.Teacher
{
    public class TeacherCreateDtoValidator:AbstractValidator<TeacherCreateDto>
    {
        public TeacherCreateDtoValidator()
        {
            RuleFor(dto => dto.FullName)
.NotEmpty().WithMessage("İsim alanı boş olamaz.")
.MaximumLength(50).WithMessage("İsim alanı en fazla 100 karakter olmalıdır.");
        }
    }
}
