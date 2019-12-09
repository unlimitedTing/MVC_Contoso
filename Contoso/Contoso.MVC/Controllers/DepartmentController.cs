using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contoso.Services;
using Contoso.Models;
using Contoso.MVC.Filter;
using Contoso.MVC.ViewModels;

namespace Contoso.MVC.Controllers
{
    //[HandleError] // put on top of the controller, handle all the error inside this controller
    [ContosoExceptionFilter]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IInstructorService _instructorService;
        //private readonly
        public DepartmentController(IDepartmentService departmentService, IInstructorService instructorService)
        {
            _departmentService = departmentService;
            _instructorService = instructorService;
        }
        // GET: Department
        public ActionResult Index()
        {

            //int i = 0;int x = 1;
            //int y = x / i;
            var departments = _departmentService.GetAllDepartments();
            //ViewData["depts"] = departments;
            ViewBag.DepartmentCount = departments.Count();
            return View(departments);// sending data to the view
        }

        [HttpGet]
        public ActionResult Create()
        {
            var instructors = _instructorService.GetAllInstructors().Select(n => new SelectListItem
            {
                Text = n.FirstName + " " + n.LastName,
                Value = n.Id.ToString()
            }).ToList();

            instructors.Insert(0,
                new SelectListItem
                {
                    Value = null,
                    Text = @"--- select Instructor ---"
                });
            // this departmentCreate variable only contains instructor data, all other properties are null
            // thus we need to pass those properties to this variable
            var departmentCreate = new CreateDepartmentViewModel
            {
                Instructors = instructors
            };
            
            return View(departmentCreate);
        }

        [HttpPost]
        public ActionResult Create(CreateDepartmentViewModel department)
        {
            //string departname,decimal budget,DateTime startdate,string DEPARTNAME,string DEPTID
            //FormCollection form
            // get the data from the form collection and call service layer
            // save to database

            try
            {
                //var departmentName = form["departname"];
                //var budget = form["budget"];
                //var startDate = form["startdate"];

                //Department department = new Department();
                //department.Name = departname;
                //department.Budget = budget;
                //department.StartDate = startdate;
                //department.InstructorId = 1;
                var newDepartment = new Department
                {
                    Name = department.Name,
                    Budget = department.Budget,
                    StartDate = department.StartDate,
                    InstructorId = department.SelectedInstructorId//why selected instructorid is 0? seems not correspond id passed in?
                };
                _departmentService.CreateDepartment(newDepartment);


                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                // return to the same page
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var department = _departmentService.GetDepartmentById(id);
            return View(department);
            
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            try
            {
                _departmentService.Update(department);//??? how to implement it generic
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View("Edit");
            }
        }
    }
}