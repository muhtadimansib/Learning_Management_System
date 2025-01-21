using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Course
    {
        public int Id { get; set; } 
        public string CourseName { get; set; }
        public string InstructorName { get; set; }
        public string Duration { get; set; }

        public List<Enrollment> Enrollments { get; set; }
        public Course() { 
            Enrollments = new List<Enrollment>();
        }
    }
}
