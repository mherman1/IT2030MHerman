using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEnrollmentApplication.Models
{
    public class Enrollment
    {
        [Display(Name = "Enrollment ID")]
        public virtual int EnrollmentID { get; set; }
        public virtual int StudentID { get; set; }
        public virtual int CourseID { get; set; }

        [Required(ErrorMessage="{0} is required")]
        [RegularExpression("[A-DFa-df]", ErrorMessage = "Only use letter grades A through F")]
        public virtual string Grade { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual bool IsActive { get; set; }

        [Required(ErrorMessage = "Campus is required")]
        [Display(Name="Assigned Campus")]
        public virtual string AssignedCampus { get; set; }

        [Required(ErrorMessage = "Semester is required")]
        [Display(Name = "Enrolled in Semester")]
        public virtual string EnrollmentSemester { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Range(2018,Double.MaxValue, ErrorMessage = "Cannot be earlier than 2018")]
        public virtual int EnrollmentYear { get; set; }
    }
}