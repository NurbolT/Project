using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class CourseGroup
    {
        
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int GroupId { get; set; }        
        public Group Group { get; set; }
    }
}
