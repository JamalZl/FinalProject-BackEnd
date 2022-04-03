using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBack_Front.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter a product name")]
        [StringLength(maximumLength:50)]
        public string Name { get; set; }
        public double Price { get; set; }
        [Required(ErrorMessage = "Please enter a product description")]
        [StringLength(maximumLength: 500)]
        public string Description { get; set; }
        public bool InStock { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public List<ProductColor> ProductColors { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public Campaign Campaign { get; set; }
        public int? CampaignId { get; set; }
        public Tag Tag { get; set; }
        public int TagId { get; set; }
        [NotMapped]
        public List<IFormFile> ImageFiles { get; set; }
        [NotMapped]
        public List<int> CategoryIds { get; set; }
        [NotMapped]
        public List<int> ColorIds { get; set; }
        [NotMapped]
        public List<int> SizeIds { get; set; }
        [NotMapped]
        public List<int> ImageIds { get; set; }




    }
}
