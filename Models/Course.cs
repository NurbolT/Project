using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Description length should be more than 10.", MinimumLength = 10)]
        public string CourseDescription { get; set; }

        public List<CourseGroup> Groups { get; set; }

    }
}
