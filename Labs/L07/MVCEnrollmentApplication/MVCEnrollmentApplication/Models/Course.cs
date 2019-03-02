using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEnrollmentApplication.Models
{
    public class Course
    {
        [Display(Name = "Course ID")]
        public virtual int CourseID { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(150, ErrorMessage = "Only 150 characters allowed")]
        [Display(Name ="Course Title")]
        public virtual string Title { get; set; }

        [Display(Name="Description")]
        public virtual string Description{ get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name="Number of Credits")]
        [Range(1,4, ErrorMessage= "Only use numbers 1 through 4")]
        public virtual int Credits { get; set; }
    }
}