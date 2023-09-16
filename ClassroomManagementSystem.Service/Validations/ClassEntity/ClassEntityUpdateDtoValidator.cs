using ClassroomManagementSystem.Core.Dtos.ClassEntity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Service.Validations.ClassEntity
{
    public class ClassEntityUpdateDtoValidator : AbstractValidator<ClassEntityUpdateDto>
    {

        public ClassEntityUpdateDtoValidator()
        {

            RuleForEach(dto => dto.LessonId)
           .GreaterThan(0).WithMessage("LessonId 0'dan büyük bir değer olmalıdır..");


            RuleFor(dto => dto.Name)
                     .NotEmpty().WithMessage("İsim alanı boş olamaz.")
                     .MaximumLength(50).WithMessage("İsim alanı en fazla 50 karakter olmalıdır.");

            RuleFor(dto => dto.Id)
                       .NotEmpty().WithMessage("Id boş olamaz.")
                       .GreaterThan(0).WithMessage("Id 0'dan büyük bir değer olmalıdır.");
        }


    }
}
