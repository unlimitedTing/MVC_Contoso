using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contoso.Services;

namespace Contoso.MVC.Controllers
{
    public class EnrollmentController : Controller
    {
        private EnrollmentService _enrollmentService;
        public EnrollmentController()
        {
            _enrollmentService = new EnrollmentService();
        }
        // GET: Enrollment
        public ActionResult Index()
        {
            // how to make user input parameters here
            var enrollments = _enrollmentService.GetAllEnrollment();
            ViewBag.EnrollmentCount = enrollments.Count();
            return View(enrollments);
        }
    }
}