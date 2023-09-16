using ClassroomManagementSystem.Core.Dtos.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Dtos.ClassEntity
{
    public class ClassEntityWithLessonDto:BaseEntityDto
    {
        public string Name { get; set; }
        public List<LessonDto> Lessons { get; set; }
    }
}
