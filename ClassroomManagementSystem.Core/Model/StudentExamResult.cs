using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Model
{
    public class StudentExamResult:BaseEntity
    {
        public byte? Exam1Grade { get; set; }
        public byte? Exam2Grade { get; set; }
        public int StudentId { get; set; }
        public int LessonId { get; set; }
        public Student Student { get; set; }
        public Lesson Lesson  { get; set; }

    }
}
