using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Model
{
    public class Student:BaseEntity
    {
        public string FullName { get; set; }
        
        
        public int ClassEntityId { get; set; }
        public ClassEntity ClassEntity { get; set; }
        public ICollection<StudentExamResult>? StudentExamResults { get; set; }
    }
}
