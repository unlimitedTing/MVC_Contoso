using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Data;
using Contoso.Models;

namespace Contoso.Services
{
    public class CourseService
    {
        CourseRepository courseRepository;
        public CourseService()
        {
            courseRepository = new CourseRepository();
        }

        public Course GetCourseById(int id)
        {
            return courseRepository.GetCourseById(id);
        }

        public IEnumerable<Course> GetAllCouses()
        {
            return courseRepository.GetAllCouses();
        }

        public IEnumerable<Course> GetAllCousesByDepartment(int departmentId)
        {
            return courseRepository.GetAllCousesByDepartment(departmentId);
        }

        public void CreateCouses(Course course)
        {
            courseRepository.Create(course);
        }

        public void Update(Course course)
        {
            courseRepository.Update(course);
        }

        
    }
}
