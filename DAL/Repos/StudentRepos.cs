using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StudentRepos : Repo, IRepo<Student, int, Student>,IStudentFeatures
    {
        public Student Create(Student obj)
        {
            db.Students.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Students.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public Student Get(int id)
        {
            return db.Students.Find(id);
        }

        public List<Student> Get()
        {
            return db.Students.ToList();
        }

        public List<Course> SeeEnrollments(int id)
        {
            var student = db.Students.Find(id);
            var enrollments = db.Enrollments.ToList();
            var courses= db.Courses.ToList();
            List<Course> enrolledcourses = new List<Course>();

            foreach (Course c in courses)
            {
                foreach (Enrollment e in enrollments)
                {
                    if(c.Id==e.CourseId && student.StudentId==e.StudentId)
                    {
                        enrolledcourses.Add(c);
                    }
                }
            }

            return enrolledcourses;
            
        }

        public Student Update(Student obj)
        {
            var ex = Get(obj.StudentId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return ex;
        }
    }
}
