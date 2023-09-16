using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Dtos.StudentExamResult
{
    public class StudentExamResultForStudent : BaseEntityDto
    {
        public int? Exam1Grade { get; set; }
        public int? Exam2Grade { get; set; }
        public int LessonId { get; set; }
    }
}
