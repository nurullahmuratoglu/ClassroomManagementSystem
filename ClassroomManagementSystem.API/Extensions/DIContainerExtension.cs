using ClassroomManagementSystem.Core.Repositories;
using ClassroomManagementSystem.Core.Services;
using ClassroomManagementSystem.Core.UnitOfWorks;
using ClassroomManagementSystem.Repository.Respositories;
using ClassroomManagementSystem.Repository.UnitOfWorks;
using ClassroomManagementSystem.Service.Services;
using System.Runtime.CompilerServices;

namespace ClassroomManagementSystem.API.Extensions
{
    public static class DIContainerExtension
    {
        public static void AddDIServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IService<,>), typeof(Service<,>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<IClassEntityService, ClassEntityService>();
            services.AddScoped<IStudentExamResultService, StudentExamResultService>();

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IClassEntityRepository, ClassEntityRepository>();
            services.AddScoped<IStudentExamResultRepository, StudentExamResultRepository>();
            services.AddScoped<IUnitOfWorks, UnitOfWorks>();

            services.AddScoped<IValidationService, ValidationService>();

        }
    }
}
