using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Model
{
    public class Lesson:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ClassEntity>? ClassEntities { get; set; }
        public ICollection<StudentExamResult>? StudentExamResults { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}