using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Model
{
    public class ClassEntityLesson
    {
        public int ClassEntityId { get; set; }
        public ClassEntity ClassEntity { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
