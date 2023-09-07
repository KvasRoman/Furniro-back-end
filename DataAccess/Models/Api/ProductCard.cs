using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniro.DataAccess.Models.Api
{
    public class ProductCard
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public bool IsNew { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string ImageUrl { get; set; }
    }
}
