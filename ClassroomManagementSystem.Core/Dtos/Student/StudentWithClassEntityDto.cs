using ClassroomManagementSystem.Core.Dtos.ClassEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Dtos.Student
{
    public class StudentWithClassEntityDto:BaseEntityDto
    {
        public string FullName { get; set; }

        public ClassEntityForStudentDto ClassEntity { get; set; }

    }
}
