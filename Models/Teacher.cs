using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Teacher
    {
        
        public int TeacherId { get; set; }
        [Required(ErrorMessage = "Please enter teacher name")]
        public string TeacherName { get; set; }
        [Required(ErrorMessage = "Please enter teacher surname")]
        public string TeacherSurname { get; set; }
        [Required]
        [EmailAddress]        
        public string TeacherEmail { get; set; }

        [Required(ErrorMessage = "Please enter the phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+[0-9]{11})$", ErrorMessage = "Not a valid phone number. The format: +7474766738")]
        public string TeacherPhone { get; set; }

        public ICollection<Section> Sections { get; set; }
       
    }

}
