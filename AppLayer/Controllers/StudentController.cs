using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppLayer.Controllers
{
    public class StudentController : ApiController
    {
        [HttpGet]
        [Route("api/students/all")]
        public HttpResponseMessage Get()
        {
            var data = StudentService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/student/{id}")]
        public HttpResponseMessage GetStudent(int id)
        {
            var data = StudentService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/student/create")]
        public HttpResponseMessage Create(StudentDTO s)
        {
            StudentService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/student/update")]
        public HttpResponseMessage Update(StudentDTO s)
        {
            StudentService.Update(s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/student/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var res=StudentService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK,res);
        }

        [HttpGet]
        [Route("api/student/SeeEnrollments/{id}")]
        public HttpResponseMessage SeeEnrollments(int id)
        {
            var res = StudentService.SeeEnrollments(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [HttpGet]
        [Route("api/student/dashboard/{id}")]
        public HttpResponseMessage GetStudentDashboard(int id)
        {
              var dashboard = StudentService.Dashboard(id);
              return Request.CreateResponse(HttpStatusCode.OK, dashboard);
            
        }

        [HttpGet]
        [Route("api/student/exportpdf")]
        public HttpResponseMessage ExportStudentsToPdf()
        {
            var filePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Students2.pdf"), "Students2.pdf");

            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                    StudentService.ExportStudentsToPdf(filePath);

                return Request.CreateResponse(HttpStatusCode.OK, new { FilePath = filePath });
            }
            catch (System.Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/students/SearchByName/{name}")]
        public HttpResponseMessage SearchByName(string name)
        {
            var data = StudentService.SearchByName(name);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


    }
}
