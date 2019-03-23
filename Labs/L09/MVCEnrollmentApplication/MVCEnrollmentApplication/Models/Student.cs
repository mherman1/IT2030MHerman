using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEnrollmentApplication.Models
{
    public class Student : IValidatableObject
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
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Address2 == Address1)
            {
                yield return new ValidationResult("Address2 cannot be the same as Address1", new[] {"Address2"});
            }

            if (State.Length != 2)
            {
                yield return new ValidationResult("Enter a 2 digit State code", new[] {"State"});
            }

            if (Zipcode.Length != 5)
            {
                yield return new ValidationResult("Enter a 5 digit Zipcode", new[] {"Zipcode"});
            }

        }

    }
}