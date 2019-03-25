using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEnrollmentApplication.Models
{
    public class InvalidCharsAttribute : ValidationAttribute
    {
        readonly string invalidChars;

        public InvalidCharsAttribute(string invalidChars) :base("{0} contains unacceptable charaters!") 
        {
            this.invalidChars = invalidChars;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                var valueAsList = value.ToString().ToList();
                if (valueAsList.Intersect(invalidChars.ToList()).Any() == true)
                {
                    var errormessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errormessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}