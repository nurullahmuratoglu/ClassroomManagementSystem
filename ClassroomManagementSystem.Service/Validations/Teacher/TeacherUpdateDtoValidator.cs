using ClassroomManagementSystem.Core.Dtos.Teacher;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Service.Validations.Teacher
{
    public class TeacherUpdateDtoValidator:AbstractValidator<TeacherUpdateDto>
    {
        public TeacherUpdateDtoValidator()
        {
            RuleFor(dto => dto.FullName)
.NotEmpty().WithMessage("İsim alanı boş olamaz.")
.MaximumLength(50).WithMessage("İsim alanı en fazla 100 karakter olmalıdır.");

            RuleFor(dto => dto.Id)
.NotEmpty().WithMessage("Id  boş olamaz.")
.GreaterThan(0).WithMessage("Id  0'dan büyük bir değer olmalıdır.");
        }
    }
}
