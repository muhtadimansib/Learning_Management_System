using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EnrollmentRepo : Repo, IRepo<Enrollment,int,Enrollment>, IEnrollmentFeatures
    {
        public Enrollment Create(Enrollment obj)
        {
            db.Enrollments.Add(obj);
            db.SaveChanges();  
            return obj;  
        }

        public bool Delete(int id)
        {
            var ex = Get(id); 
            if (ex != null)
            {
                db.Enrollments.Remove(ex);  
                return db.SaveChanges() > 0; 
            }
            return false; 
        }

        public Enrollment Get(int id)
        {
            return db.Enrollments.Find(id); 
        }

        public List<Enrollment> Get()
        {
            return db.Enrollments.ToList();  
        }

        public List<object> GetCoursesWithEnrolledStudents()
        {
            var courses = db.Courses.ToList();
            var enrollments = db.Enrollments.ToList();

            var result = courses.Select(course => new Dictionary<string, object>
            {
                { "CourseId", course.Id },
                { "CourseName", course.CourseName },
                { "InstructorName", course.InstructorName },
                { "EnrolledStudents", enrollments
                    .Where(e => e.CourseId == course.Id)
                    .Select(e => new Dictionary<string,object>
                    {
                        { "StudentId", e.StudentId },
                        {"Name", db.Students.Find(e.StudentId).Name },
                        {"Email", db.Students.Find(e.StudentId).Email },
                        {"Phone", db.Students.Find(e.StudentId).PhoneNumber },
                        {"CGPA", db.Students.Find(e.StudentId).CGPA }
                        
                    })
                    .ToList()
                }
                
            }).ToList<object>();

            return result;
        }

        public Enrollment Update(Enrollment obj)
        {
            var ex = Get(obj.EnrollId);  
            if (ex != null)
            {
                db.Entry(ex).CurrentValues.SetValues(obj); 
                db.SaveChanges(); 
                return ex;  
            }
            return null;  
        }
    }
}
