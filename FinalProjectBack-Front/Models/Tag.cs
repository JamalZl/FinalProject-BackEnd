using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBack_Front.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter a tag name")]
        [StringLength(maximumLength:15)]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
