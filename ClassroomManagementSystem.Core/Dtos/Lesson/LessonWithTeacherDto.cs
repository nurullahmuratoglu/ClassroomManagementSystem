using ClassroomManagementSystem.Core.Dtos.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Dtos.Lesson
{
    public class LessonWithTeacherDto:BaseEntityDto
    {
        public string Name { get; set; }
        public TeacherForLessonDto Teacher { get; set; }
    }
}
