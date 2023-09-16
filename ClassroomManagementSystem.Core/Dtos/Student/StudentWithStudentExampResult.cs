using ClassroomManagementSystem.Core.Dtos.StudentExamResult;
using ClassroomManagementSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Dtos.Student
{
    public class StudentWithStudentExampResult:BaseEntityDto
    {
        public string FullName { get; set; }

        public List<StudentExamResultDto> StudentExamResults { get; set; }
    }
}
