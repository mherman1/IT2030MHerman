using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventApplication.Models
{
    public class Event : IValidatableObject
    {
        public virtual int EventId { get; set; }

        public virtual int EventTypeId { get; set; }

        public virtual EventType Type { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "Only 50 characters allowed")]
        public virtual string Title { get; set; }

        [StringLength(50, ErrorMessage = "Only 150 characters allowed")]
        public virtual string Description { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Start Date")]
        public virtual DateTime StartDate { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "End Date")]
        public virtual DateTime EndDate { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Max Tickets")]
        [Range(1, int.MaxValue)]
        public virtual int MaxTickets { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Available Tickets")]
        [Range(1, int.MaxValue)]
        public virtual int AvailableTickets { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public virtual string Organizer { get; set; }

        [Display(Name = "Organizer Contact Info")]
        public virtual string OrganizerContactInfo { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public virtual string City { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public virtual string State { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate < DateTime.Now)
            {
                yield return new ValidationResult("Start Date cannot be earlier than the current date and time", new[] { "StartDate" });
            }

            if (EndDate < DateTime.Now)
            {
                yield return new ValidationResult("End Date cannot be earlier than the current date and time", new[] { "EndDate" });
            }

            if (EndDate < StartDate)
            {
                yield return new ValidationResult("End Date must be later than the Start Date", new[] { "EndDate" });
            }

        }
    }
}