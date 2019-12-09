using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Contoso.Services;
using Contoso.Models;

namespace Contoso.API.Controllers
{
    // MVC and API inherients from different class, 
    // mvc inherient from Controller
    // api inherient from ApiController
    
    // this rote prefix work for all below class members
    [RoutePrefix("api/departments")]
    public class DepartmentController : ApiController
    {
        // initilize department service interface variable
        private readonly IDepartmentService _departmentService;

        // build constructor with parameter passed into it
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // method
        [HttpGet]
        [Route("")]
        public IEnumerable<Department> GetDepartments()
        {
            var departments = _departmentService.GetAllDepartments();
            return departments;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetDepartmentById(int id)
        {
            var department = _departmentService.GetDepartmentById(id);
            if (department ==null)
            {
                var response = Request.CreateResponse(HttpStatusCode.NotFound, "No Department Found");
                return ResponseMessage(response);
            }


            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, department));
        }
    }
}
