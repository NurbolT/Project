using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Director
    {
        [Key]
        [ForeignKey("Section")]

        [Remote("SectionExist", "Directors", ErrorMessage = "This section already have a director! Please,change the section!")]
        public int SectionId { get; set; }
        [Required]
        public string DirectorName { get; set; }
        [Required]
        public string DirectorSurname { get; set; }
        [Required]
        [EmailAddress]
        public string DirectorEmail { get; set; }

        public virtual Section Section { get; set; }
    }
}
