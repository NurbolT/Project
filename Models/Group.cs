using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Group
    {
        
        public int GroupId { get; set; }
        [Required]
        public string GroupNumber { get; set; }
        public List<CourseGroup> Courses { get; set; }
    }
}
