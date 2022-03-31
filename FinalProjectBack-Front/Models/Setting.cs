using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBack_Front.Models
{
    public class Setting
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter an icon")]
        public string MenuIcon { get; set; }
        [Required(ErrorMessage = "Please enter an icon")]
        public string CloseIcon { get; set; }
        public string Logo { get; set; }
        [Required(ErrorMessage = "Please enter an icon")]
        public string SearchIcon { get; set; }
        [Required(ErrorMessage = "Please enter an icon")]
        public string UserIcon { get; set; }
        [Required(ErrorMessage = "Please enter an icon")]
        public string WhishlistIcon { get; set; }
        [Required(ErrorMessage = "Please enter an icon")]
        public string BasketIcon { get; set; }
        public string HandpickedImage { get; set; }
        [StringLength(maximumLength:20)]
        [Required(ErrorMessage = "HandpickedSale is required")]
        public string HandpickedSale { get; set; }
        [StringLength(maximumLength: 10)]
        [Required(ErrorMessage = "HandpickedSaleTitle is required")]
        public string HandpickedSaleTitle { get; set; }
        public string NewArrivalImage { get; set; }
        public string FunImage { get; set; }
        public string UpliftedImage { get; set; }
        [Required(ErrorMessage ="SubscribeTitle is required")]
        [StringLength(maximumLength:50)]
        public string SubscribeTitle { get; set; }
        public string SubscribeImage { get; set; }
        [Required(ErrorMessage ="FooterAdress is required")]
        [StringLength(maximumLength:30)]
        public string FooterAddress { get; set; }
        [Required(ErrorMessage ="Please enter an icon")]
        public string FooterAdressIcon { get; set; }
        [Required(ErrorMessage ="FooterEmail is required")]
        [StringLength(maximumLength:50)]
        public string FooterEmail { get; set; }
        [Required(ErrorMessage = "Please enter an icon")]
        public string FooterEmailIcon { get; set; }
        [Required(ErrorMessage = "Please enter an icon")]
        public string FooterNumberIcon { get; set; }
        [Required(ErrorMessage ="FooterNumber is required")]
        [StringLength(maximumLength: 30)]
        public string FooterNumber { get; set; }
        public string FooterPaymentImage { get; set; }
        [NotMapped]
        public IFormFile LogoImageFile { get; set; }
        [NotMapped]
        public IFormFile HandpickedImageFile { get; set; }
        [NotMapped]
        public IFormFile NewArrivalImageFile { get; set; }
        [NotMapped]
        public IFormFile FunImageFile { get; set; }
        [NotMapped]
        public IFormFile UpliftedImageFile { get; set; }
        [NotMapped]
        public IFormFile SubscribeImageFile { get; set; }
        [NotMapped]
        public IFormFile FooterPaymentImageFile { get; set; }

    }
}
