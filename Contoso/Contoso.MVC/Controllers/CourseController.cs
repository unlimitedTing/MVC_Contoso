using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contoso.Services;
using Contoso.Models;

namespace Contoso.MVC.Controllers
{
    public class CourseController : Controller
    {
        private CourseService _courseService;//why private?

        public CourseController() => _courseService = new CourseService();


        // GET: Course
        public ActionResult Index()
        {
            var courses = _courseService.GetAllCouses();
            ViewBag.CourseCount = courses.Count();
            return View(courses);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            try
            {
                _courseService.CreateCouses(course);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var course=_courseService.GetCourseById(id);
            return View(course);
        }

        [HttpPost]
        public ActionResult Edit(Course course)
        {
            try
            {
                _courseService.Update(course);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View("Edit");
            }
        }
    }
}