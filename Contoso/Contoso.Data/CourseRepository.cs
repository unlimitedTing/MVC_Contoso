using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Models;

namespace Contoso.Data
{
    public class CourseRepository
    {
        ContosoDbContext db;
        public CourseRepository()
        {
            db = new ContosoDbContext();
        }

        public Course GetCourseById(int id)
        {
            return db.Courses.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Course> GetAllCouses()
        {
            return db.Courses.ToList();
        }

        public IEnumerable<Course> GetAllCousesByDepartment(int departmentId)
        {
            return db.Courses.Where(e => e.DepartmentId == departmentId).ToList();
        }

        public void Create(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
        }

        public void Update(Course course)
        {
            var targetCourse = db.Courses.Find(course.Id);
            targetCourse.Title = course.Title;
            targetCourse.Credits = course.Credits;
            targetCourse.StartDate = course.StartDate;
            targetCourse.DepartmentId = course.DepartmentId;
            db.SaveChanges();
        }

    }
}
