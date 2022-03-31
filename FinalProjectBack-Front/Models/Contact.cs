using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBack_Front.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage ="Description is required")]
        [StringLength(maximumLength:300)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(maximumLength: 70)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [StringLength(maximumLength: 70)]
        public string Email { get; set; }
        [Required(ErrorMessage = "WorkingHours is required")]
        [StringLength(maximumLength: 50)]
        public string WorkingHours { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
