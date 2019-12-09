using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public int Grade { get; set; }

        // navigation property

        public Course Course { get; set; }

        public Student Student { get; set; }


    }
}
