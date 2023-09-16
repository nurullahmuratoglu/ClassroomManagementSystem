using ClassroomManagementSystem.Core.Dtos.Student;
using ClassroomManagementSystem.Core.Dtos.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Dtos.ClassEntity
{
    public class ClassEntityWithStudentDto:BaseEntityDto
    {
        public string Name { get; set; }
        public ICollection<StudentDto>? Students { get; set; }
    }
}