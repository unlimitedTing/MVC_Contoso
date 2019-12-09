using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Models;
using Contoso.Data;

namespace Contoso.Services
{
    public class EnrollmentService
    {
        EnrollmentRepository enrollmentRepository;
        public EnrollmentService()
        {
            enrollmentRepository = new EnrollmentRepository();
        }

        public IEnumerable<Enrollment> GetAllEnrollment()
        {
            return enrollmentRepository.GetAllEnrollment().ToList();
        }

        public IEnumerable<int> GetCourseIdByStudentId(int studentId)
        {
            return enrollmentRepository.GetCourseIdByStudentId(studentId);
        }

        public IEnumerable<string> GetCourseByStudnetId(int studentId)
        {
            return enrollmentRepository.GetCourseByStudnetId(studentId);
        }

        public IEnumerable<string> GetAllStudentNameByCourseId(int courseId)
        {
            return enrollmentRepository.GetAllStudentNameByCourseId(courseId);
        }

        public void Create(Enrollment enrollment)
        {
            enrollmentRepository.Create(enrollment);
        }

        public void Update(Enrollment enrollment)
        {
            enrollmentRepository.Update(enrollment);
        }
    }
}
