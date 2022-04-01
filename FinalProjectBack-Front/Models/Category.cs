using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBack_Front.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter a category name")]
        [StringLength(maximumLength:25)]
        public string Name { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
