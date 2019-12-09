using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public DateTime StartDate { get; set; }
        public int DepartmentId { get; set; }

        // navigation property
        public Department Department { get; set; } 

        public ICollection<Instructor> Instructors { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }


    }
}
