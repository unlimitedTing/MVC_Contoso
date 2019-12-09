using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contoso.MVC.ViewModels
{
    public class CreateDepartmentViewModel
    {
        public int Id { get; set; }

        [MaxLength(150)]
        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Budget")]
        [Range(100, 100000)]
        [DataType(DataType.Currency)]
        public decimal Budget { get; set; }

        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please select a Instructor")]
        [Display(Name = "Instructor")]
        public int SelectedInstructorId { get; set; }

        public IEnumerable<SelectListItem> Instructors { get; set; }
    }
}