using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBack_Front.Models
{
    public class Size
    {
        public int Id { get; set; }
        [Required]
        public int Name { get; set; }
    }
}
