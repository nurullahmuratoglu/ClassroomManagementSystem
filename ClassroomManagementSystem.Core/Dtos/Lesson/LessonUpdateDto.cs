using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Dtos.Lesson
{
    public class LessonUpdateDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<int>? ClassEntityId { get; set; }
        public int TeacherId { get; set; }
    }
}
