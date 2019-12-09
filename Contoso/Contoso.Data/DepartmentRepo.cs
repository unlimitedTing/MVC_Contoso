using Contoso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data
{
    public class DepartmentRepo
    {
        ContosoDbContext db;
        public DepartmentRepo()
        {
            db = new ContosoDbContext();
        }

        //ContosoDbContext db=new ContosoDbContext();// why cannot create private object
        public Department GetDepartmentById(int id)
        {
            return db.Departments.FirstOrDefault(e => e.ID == id);
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return db.Departments.ToList();
        }

        public Department GetDepartmentByName(string name)
        {
            return db.Departments.FirstOrDefault(e => e.Name == name);
        }

        public void Create(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
        }

        public void UpdateById(Department department)
        {
            var depart = db.Departments.Find(department.ID);
            depart.ID = department.ID;
            depart.Name = department.Name;
            depart.Budget = department.Budget;
            depart.InstructorId = department.InstructorId;
            depart.StartDate = department.StartDate;
            db.SaveChanges();

        }
        public Department GetHighestDepartment()
        {
            //return db.Departments.FirstOrDefault(e=>e.Budget==(from department in db.Departments select department.Budget).Max());
            return db.Departments.OrderByDescending(e => e.Budget).FirstOrDefault();
        }

    }
}
