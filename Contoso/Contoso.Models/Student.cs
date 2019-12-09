using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Models
{   
    [Table("Student")]
    public class Student:Person
    {
        public new int Id { get; set; }
        public DateTime EnrollmentDate { get; set; }

        // navigation properties
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
