﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Dtos.ClassEntity
{
    public class ClassEntityUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int>? LessonId { get; set; }
    }
}
