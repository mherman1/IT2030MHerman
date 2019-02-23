using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEnrollmentApplication.Models
{
    public class Student
    {
        [Display(Name = "Student ID")]
        public virtual int StudentID { get; set; }

        [Required(ErrorMessage="{0} is required")]
        [StringLength(50, ErrorMessage ="Only 50 characters allowed")]
        [Display(Name ="First Name")]
        public virtual string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "Only 50 characters allowed")]
        [Display(Name = "Last Name")]
        public virtual string LastName { get; set; }

    }
}