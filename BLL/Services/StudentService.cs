using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentDTO>();
                cfg.CreateMap<StudentDTO, Student>();
                cfg.CreateMap<Enrollment,EnrollmentDTO>();
            });
            return new Mapper(config);
        }
        public static List<StudentDTO> Get()
        {
            var repo = DataAccessFactory.StudentData();
            return GetMapper().Map<List<StudentDTO>>(repo.Get());
        }
        public static StudentDTO Get(int id)
        {
            var repo = DataAccessFactory.StudentData();
            return GetMapper().Map<StudentDTO>(repo.Get(id));

        }

        public static void Create(StudentDTO s)
        {
            var repo = DataAccessFactory.StudentData();
            repo.Create(GetMapper().Map<Student>(s));
        }

        public static void Update(StudentDTO s)
        {
            var repo = DataAccessFactory.StudentData();
            repo.Update(GetMapper().Map<Student>(s));
        }

        public static string Delete(int id)
        {
            var repo = DataAccessFactory.StudentData();
            var res=repo.Delete(id);
            return res ? "Deleted" : "Deletion Failed";
        }

        public static List<EnrollmentDTO> SeeEnrollments(int id)
        {
            var repo= DataAccessFactory.StudentFeatures();
            return GetMapper().Map<List<EnrollmentDTO>>(repo.SeeEnrollments(id));

        }

        public static List<object> Dashboard(int id)
        {
            var repo = DataAccessFactory.StudentFeatures();
            return repo.Dashoard(id);
        }

        public static void ExportStudentsToPdf(string filepath)
        {
            var repo=DataAccessFactory.StudentFeatures();
            repo.ExportStudentsToPdf(filepath);
        }

        public static List<StudentDTO> SearchByName(string name)
        {
            var repo = DataAccessFactory.StudentFeatures();
            return GetMapper().Map<List<StudentDTO>>(repo.SearchByName(name));
        }

    }
}
