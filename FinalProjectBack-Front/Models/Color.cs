using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBack_Front.Models
{
    public class Color
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a color name")]
        [StringLength(maximumLength: 20)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter a color value")]
        [StringLength(maximumLength:25)]
        public string Value { get; set; }
        public List<ProductColor> ProductColors { get; set; }
    }
}
