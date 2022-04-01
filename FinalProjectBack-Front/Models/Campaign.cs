using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBack_Front.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public int DiscountPercent { get; set; }
        public List<Product> Products { get; set; }
    }
}
