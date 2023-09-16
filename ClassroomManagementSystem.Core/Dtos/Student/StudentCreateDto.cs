using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Dtos.Student
{
    public class StudentCreateDto
    {
        public string FullName { get; set; }
        public int ClassEntityId { get; set; }
    }
}
