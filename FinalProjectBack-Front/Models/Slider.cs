using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBack_Front.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Title is required")]
        [StringLength(maximumLength:20)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(maximumLength: 50)]
        public string Description { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
