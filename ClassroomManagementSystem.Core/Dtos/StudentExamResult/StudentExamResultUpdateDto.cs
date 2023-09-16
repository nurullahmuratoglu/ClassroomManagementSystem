using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Dtos.StudentExamResult
{
    public class StudentExamResultUpdateDto
    {
        public int Id { get; set; }
        public byte? Exam1Grade { get; set; }
        public byte? Exam2Grade { get; set; }
        public int StudentId { get; set; }
        public int LessonId { get; set; }
    }
}
