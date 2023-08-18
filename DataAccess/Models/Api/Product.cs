using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniro.DataAccess.Models.Api
{
    public class Product
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string BriefDescription { get; set; }
        public string ShortDesctiption { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public decimal Price { get; set; }
        public bool IsNew { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string SKU { get; set; }

        public Guid[] Images { get; set; }
    }
}
