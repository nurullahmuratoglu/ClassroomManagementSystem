using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Model
{
    public class ClassEntity:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Lesson>? Lessons { get; set; }
        public ICollection<Student>? Students { get; set; }

    }
}
