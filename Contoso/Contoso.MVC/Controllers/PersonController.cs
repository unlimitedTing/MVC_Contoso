using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contoso.Services;
using Contoso.Models;

namespace Contoso.MVC.Controllers
{
    public class PersonController : Controller
    {
        private PersonService _personService;
        public PersonController()
        {
            _personService = new PersonService();
        }
        // GET: Person
        public ActionResult Index()
        {
            var people = _personService.GetAllPeople();
            ViewBag.DepartmentCount = people.Count();
            return View(people);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            try
            {
                _personService.Create(person);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var person = _personService.GetPersonById(id);
            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            try
            {
                _personService.Update(person);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View("Edit");
            }
        }
    }
}