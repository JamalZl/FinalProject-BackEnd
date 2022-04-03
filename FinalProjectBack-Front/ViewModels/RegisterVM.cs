using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBack_Front.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="Please enter your username")]
        [StringLength(maximumLength: 30)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [StringLength(maximumLength: 70)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your name")]

        [StringLength(maximumLength: 30)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your surname")]

        [StringLength(maximumLength: 30)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please enter password")]

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please confirm your password")]

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage ="Please enter telephone number")]
        public string TelephoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter age")]
        public int Age { get; set; }
    }
}
