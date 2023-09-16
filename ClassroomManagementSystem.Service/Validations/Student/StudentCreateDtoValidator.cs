using ClassroomManagementSystem.Core.Dtos.Lesson;
using ClassroomManagementSystem.Core.Dtos.Student;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Service.Validations.Student
{
    public class StudentCreateDtoValidator: AbstractValidator<StudentCreateDto>
    {
        public StudentCreateDtoValidator()
        {
            RuleFor(dto => dto.FullName)
    .NotEmpty().WithMessage("İsim alanı boş olamaz.")
    .MaximumLength(50).WithMessage("İsim alanı en fazla 100 karakter olmalıdır.");

            RuleFor(dto => dto.ClassEntityId)
           .NotEmpty().WithMessage("ClassId boş olamaz.")
           .GreaterThan(0).WithMessage("ClassID  0'dan büyük bir değer olmalıdır.");


        }
    }
}
