using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Dtos.Lesson
{
    public class LessonCreateDto
    {
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public List<int>? ClassEntitiesId { get; set; }
    }
}
