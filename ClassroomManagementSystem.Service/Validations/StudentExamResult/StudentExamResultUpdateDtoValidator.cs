using ClassroomManagementSystem.Core.Dtos.StudentExamResult;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Service.Validations.StudentExamResult
{
    public class StudentExamResultUpdateDtoValidator:AbstractValidator<StudentExamResultUpdateDto>
    {
        public StudentExamResultUpdateDtoValidator()
        {
            RuleFor(dto => dto.Id)
.NotEmpty().WithMessage("Id  boş olamaz.")
.GreaterThan(0).WithMessage("Id  0'dan büyük bir değer olmalıdır.");

            RuleFor(dto => dto.Exam1Grade)
    .Custom((value, context) =>
    {
        if (value < 0 || value > 100)
        {
            context.AddFailure("not 0 ile 100 arasında olmalıdır.");
        }
    });


            RuleFor(dto => dto.Exam2Grade)
    .Custom((value, context) =>
    {
        if (value < 0 || value > 100)
        {
            context.AddFailure("not 0 ile 100 arasında olmalıdır.");
        }
    });


            RuleFor(dto => dto.StudentId)
.NotEmpty().WithMessage("Id  boş olamaz.")
.GreaterThan(0).WithMessage("Id  0'dan büyük bir değer olmalıdır.");

            RuleFor(dto => dto.LessonId)
.NotEmpty().WithMessage("Id  boş olamaz.")
.GreaterThan(0).WithMessage("Id  0'dan büyük bir değer olmalıdır.");
        }
    }
}
