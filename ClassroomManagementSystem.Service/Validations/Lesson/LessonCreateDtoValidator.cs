using ClassroomManagementSystem.Core.Dtos.Lesson;
using ClassroomManagementSystem.Service.Validations.ClassEntity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Service.Validations.Lesson
{
    public class LessonCreateDtoValidator :AbstractValidator<LessonCreateDto>
    {
        public LessonCreateDtoValidator()
        {


            RuleForEach(dto => dto.ClassEntitiesId)
           .GreaterThan(0).WithMessage("Id 0'dan büyük bir değer olmalıdır..");


            RuleFor(dto => dto.Name)
                    .NotEmpty().WithMessage("İsim alanı boş olamaz.")
                    .MaximumLength(50).WithMessage("İsim alanı en fazla 50 karakter olmalıdır.");

            RuleFor(dto => dto.TeacherId)
                       .NotEmpty().WithMessage("TeacherId Id boş olamaz.")
                       .GreaterThan(0).WithMessage("TeacherId  0'dan büyük bir değer olmalıdır.");
        }
    }
}
