using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Enrollment
    {
        [Key]
        public int EnrollId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Progress { get; set; } 

        [ForeignKey("Student")]
        public int StudentId { get; set; } 
        public Student Student { get; set; } 

        [ForeignKey("Course")]
        public int CourseId { get; set; } 
        public Course Course { get; set; } 
    }
}
