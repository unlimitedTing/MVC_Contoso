using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Models
{
    public class OfficeAssignment
    {
        [Key,ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        public string Location { get; set; }

        // navigation properties
        public Instructor Instructor { get; set; }
    }
}
