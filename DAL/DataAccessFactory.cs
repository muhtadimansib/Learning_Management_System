using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Student, int, Student> StudentData()
        {
            return new StudentRepos();
        }

        public static IRepo<Course, int, Course> CourseData()
        {
            return new CourseRepo();
        }

        public static IRepo<Enrollment, int, Enrollment> EnrollmentData()
        {
            return new EnrollmentRepo();
        }

        public static IEnrollmentFeatures EnrollmentFeatures()
        {
            return new EnrollmentRepo();
        }

        public static IStudentFeatures StudentFeatures()
        {
            return new StudentRepos();
        }
    }
}
