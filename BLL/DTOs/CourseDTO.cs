﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string InstructorName { get; set; }
        public string Duration { get; set; }
    }
}
