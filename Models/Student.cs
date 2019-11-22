using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Student : IValidatableObject
    {
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentSurname { get; set; }

        

        [Required]
        [EmailAddress]
        public string StudentEmail { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+[0-9]{11})$", ErrorMessage = "Not a valid phone number. The format: +7474766738")]
        public string StudentTelephone { get; set; }

        public int SectionId { get; set; }
        public Section Section { get; set; }

        [Required]
        public int StudentAge { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StudentAge < 12 || StudentAge > 21) {
                yield return new ValidationResult("The age should be more than 12 and less than 21!");
            } 
        }
    }
}
