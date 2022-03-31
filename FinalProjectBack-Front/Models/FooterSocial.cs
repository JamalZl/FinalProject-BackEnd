using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBack_Front.Models
{
    public class FooterSocial
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter an icon")]
        public string SocialIcon { get; set; }
        [Required(ErrorMessage ="Please enter a social media url")]
        public string SocialUrl { get; set; }
    }
}
