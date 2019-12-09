using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Models;

namespace Contoso.Data
{
    public class EnrollmentRepository
    {
        ContosoDbContext db;
        public EnrollmentRepository()
        {
            db = new ContosoDbContext();
        }

        public IEnumerable<Enrollment> GetAllEnrollment()
        {
            return db.Enrollments.ToList();
        }

        public IEnumerable<int> GetCourseIdByStudentId(int studentId)
        {
            return db.Enrollments.Where(e => e.StudentId == studentId).Select(e => e.CourseId).ToList();
        }

        public IEnumerable<string> GetCourseByStudnetId(int studentId)
        {
            return db.Enrollments.Where(e => e.StudentId == studentId).Select(e => e.Course.Title).ToList();
        }

        public IEnumerable<string> GetAllStudentNameByCourseId(int courseId)
        {
            return db.Enrollments.Where(e => e.CourseId == courseId).Select(e => e.Student.LastName + e.Student.FirstName).ToList();
        }

        public void Create(Enrollment enrollment)
        {

        }

        public void Update(Enrollment enrollment)
        {

        }
     }

}
