using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CourseRepo: Repo,IRepo<Course, int, Course>, ICourseFeatures
    {
        public Course Create(Course obj)
        {
            db.Courses.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Courses.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public Course Get(int id)
        {
            return db.Courses.Find(id);
        }

        public List<Course> Get()
        {
            return db.Courses.ToList();
        }

        public List<Course> GetCoursesSortedByDuration()
        {
            return db.Courses.OrderByDescending(c => c.Duration).ToList();
        }

        public Course Update(Course obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return ex;
        }
    }
}
