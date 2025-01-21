using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppLayer.Controllers
{
    public class CourseController : ApiController
    {
        [HttpGet]
        [Route("api/Courses/all")]
        public HttpResponseMessage Get()
        {
            var data = CourseService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/Course/{id}")]
        public HttpResponseMessage GetCourse(int id)
        {
            var data = CourseService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/Course/create")]
        public HttpResponseMessage Create(CourseDTO s)
        {
            CourseService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/Course/update")]
        public HttpResponseMessage Update(CourseDTO s)
        {
            CourseService.Update(s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/Course/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var res = CourseService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }
}
