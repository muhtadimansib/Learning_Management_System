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
    public class CourseService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Course, CourseDTO>();
                cfg.CreateMap<CourseDTO, Course>();
            });
            return new Mapper(config);
        }
        public static List<CourseDTO> Get()
        {
            var repo = DataAccessFactory.CourseData();
            return GetMapper().Map<List<CourseDTO>>(repo.Get());
        }
        public static CourseDTO Get(int id)
        {
            var repo = DataAccessFactory.CourseData();
            return GetMapper().Map<CourseDTO>(repo.Get(id));

        }

        public static void Create(CourseDTO s)
        {
            var repo = DataAccessFactory.CourseData();
            repo.Create(GetMapper().Map<Course>(s));
        }

        public static void Update(CourseDTO s)
        {
            var repo = DataAccessFactory.CourseData();
            repo.Update(GetMapper().Map<Course>(s));
        }

        public static string Delete(int id)
        {
            var repo = DataAccessFactory.CourseData();
            var res = repo.Delete(id);
            return res ? "Deleted" : "Deletion Failed";
        }
    }
}
