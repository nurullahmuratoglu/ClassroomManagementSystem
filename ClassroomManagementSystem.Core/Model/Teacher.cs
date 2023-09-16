using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Model
{
    public class Teacher:BaseEntity
    {
        public string FullName { get; set; }
        
        public ICollection<Lesson> Lessons { get; set; }
    }
}
