using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Section
    {
        public int SectionId { get; set; }
        [Required]
        public string SectionName { get; set; }

        public virtual Director Director { get; set; }
        public virtual Classroom Classroom { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public ICollection<Student> Students { get; set; }
        
    }
}
