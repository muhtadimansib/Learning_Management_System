using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EnrollmentService
    {

        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Enrollment, EnrollmentDTO>();
                cfg.CreateMap<EnrollmentDTO, Enrollment>();
            });
            return new Mapper(config);
        }

        public static List<EnrollmentDTO> Get()
        {
            var repo = DataAccessFactory.EnrollmentData(); 
            var enrollments = repo.Get(); 
            return GetMapper().Map<List<EnrollmentDTO>>(enrollments); 
        }

        public static EnrollmentDTO Get(int id)
        {
            var repo = DataAccessFactory.EnrollmentData();
            var enrollment = repo.Get(id); 
            return enrollment == null ? null : GetMapper().Map<EnrollmentDTO>(enrollment); 
        }

        public static void Create(EnrollmentDTO enrollmentDTO)
        {
            var repo = DataAccessFactory.EnrollmentData();
            var enrollment = GetMapper().Map<Enrollment>(enrollmentDTO); 
            repo.Create(enrollment); 
        }


        public static void Update(EnrollmentDTO enrollmentDTO)
        {
            var repo = DataAccessFactory.EnrollmentData();
            var enrollment = GetMapper().Map<Enrollment>(enrollmentDTO); 
            repo.Update(enrollment);
        }


        public static string Delete(int id)
        {
            var repo = DataAccessFactory.EnrollmentData();
            var enrollment = repo.Get(id); 
            if (enrollment == null)
            {
                return "Enrollment not found";
            }
            var result = repo.Delete(id); 
            return result ? "Deleted" : "Deletion failed";
        }

        public static List<object> GetCoursesWithEnrolledStudents()
        {
            var repo = DataAccessFactory.EnrollmentFeatures();
            return repo.GetCoursesWithEnrolledStudents();
        }
    }
}
