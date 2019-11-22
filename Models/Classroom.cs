using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Classroom
    {
        [Key]
        [ForeignKey("Section")]
        [Remote("SectionExist", "Classrooms", ErrorMessage = "This section already have a classroom! Please,change the section!")]
        public int SectionId { get; set; }
        [Required]        
        public string ClassNumber { get; set; }
        public virtual Section Section { get; set; }
    }
}
