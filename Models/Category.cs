using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

        [StringLength(100, ErrorMessage = "Description length should be more than 10.", MinimumLength = 10)]
        public string CategoryDescription { get; set; }

        public ICollection<Section> Sections { get; set; }

    }
}
