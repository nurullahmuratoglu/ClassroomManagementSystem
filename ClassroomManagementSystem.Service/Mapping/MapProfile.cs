using AutoMapper;
using ClassroomManagementSystem.Core.Dtos.ClassEntity;
using ClassroomManagementSystem.Core.Dtos.Lesson;
using ClassroomManagementSystem.Core.Dtos.Student;
using ClassroomManagementSystem.Core.Dtos.StudentExamResult;
using ClassroomManagementSystem.Core.Dtos.Teacher;
using ClassroomManagementSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Student, StudentCreateDto>().ReverseMap();
            CreateMap<Student, StudentUpdateDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, StudentWithClassEntityDto>().ReverseMap();
            CreateMap<Student, StudentWithStudentExampResult>().ReverseMap();
           

            CreateMap<Teacher, TeacherCreateDto>().ReverseMap();
            CreateMap<Teacher, TeacherUpdateDto>().ReverseMap();
            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<Teacher, TeacherForLessonDto>().ReverseMap();



            CreateMap<Lesson, LessonCreateDto>().ReverseMap();
            CreateMap<Lesson, LessonUpdateDto>().ReverseMap();
            CreateMap<Lesson, LessonDto>().ReverseMap();
            CreateMap<Lesson, LessonWithTeacherDto>().ReverseMap();



            CreateMap<ClassEntity, ClassEntityCreateDto>().ReverseMap();
            CreateMap<ClassEntity, ClassEntityUpdateDto>().ReverseMap();
            CreateMap<ClassEntity, ClassEntityDto>().ReverseMap();
            CreateMap<ClassEntity, ClassEntityForStudentDto>().ReverseMap();
            CreateMap<ClassEntity, ClassEntityWithLessonDto>().ReverseMap();
            CreateMap<ClassEntity, ClassEntityWithStudentDto>().ReverseMap();


            CreateMap<StudentExamResult, StudentExamResultDto>().ReverseMap();
            CreateMap<StudentExamResult, StudentExamResultCreateDto>().ReverseMap();
            CreateMap<StudentExamResult, StudentExamResultUpdateDto>().ReverseMap();
            CreateMap<StudentExamResult, StudentExamResultForStudent>().ReverseMap();
            



        }
    }
}
