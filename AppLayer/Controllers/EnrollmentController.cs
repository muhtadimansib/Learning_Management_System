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
    public class EnrollmentController : ApiController
    {
        [HttpGet]
        [Route("api/enrollments/all")]
        public HttpResponseMessage Get()
        {
            var data = EnrollmentService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // Get enrollment by ID
        [HttpGet]
        [Route("api/enrollment/{id}")]
        public HttpResponseMessage GetEnrollment(int id)
        {
            var data = EnrollmentService.Get(id);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Enrollment not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // Create new enrollment
        [HttpPost]
        [Route("api/enrollment/create")]
        public HttpResponseMessage Create(EnrollmentDTO enrollment)
        {
            if (enrollment == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid enrollment data");
            }

            EnrollmentService.Create(enrollment);
            return Request.CreateResponse(HttpStatusCode.OK, "Enrollment created successfully");
        }

        // Update an existing enrollment
        [HttpPut]
        [Route("api/enrollment/update")]
        public HttpResponseMessage Update(EnrollmentDTO enrollment)
        {
            if (enrollment == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid enrollment data");
            }

            var existing = EnrollmentService.Get(enrollment.EnrollId);
            if (existing == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Enrollment not found");
            }

            EnrollmentService.Update(enrollment);
            return Request.CreateResponse(HttpStatusCode.OK, "Enrollment updated successfully");
        }

        // Delete enrollment by ID
        [HttpDelete]
        [Route("api/enrollment/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = EnrollmentService.Delete(id);
            if (result == "Deleted")
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Enrollment deleted successfully");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Enrollment not found or deletion failed");
        }

        [HttpGet]
        [Route("api/enrollment/courses-with-students")]
        public HttpResponseMessage GetCoursesWithEnrolledStudents()
        {
            var data = EnrollmentService.GetCoursesWithEnrolledStudents();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
