using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 
        public string PhoneNumber { get; set; }
        public double CGPA {  get; set; } 

        public List<Enrollment> Enrollments { get; set; }
        public Student() {
            Enrollments = new List<Enrollment>();
        }
    }
}
