using Furniro.DataAccess.Models.DataAccess.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using api = Furniro.DataAccess.Models.Api;
namespace Furniro.DataAccess.Models.DataAccess
{
    [PrimaryKey("Id")]
    public class Product
    {
        public Product() { }
        public Product(api.Product product)
        {
            this.Id = Guid.NewGuid();
            this.Category = product.Category;
            this.Name = product.Name;
            this.BriefDescription = product.BriefDescription;
            this.ShortDescription = product.ShortDescription;
            this.Description = product.Description;
            this.Rating = product.Rating;
            this.Price = product.Price;
            this.IsNew = product.IsNew;
            this.DiscountPercentage = product.DiscountPercentage;
            this.DiscountedPrice = product.DiscountedPrice;
            this.SKU = product.SKU;
        }
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string BriefDescription { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public decimal Price { get; set; }
        public bool IsNew { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string SKU { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual SeatProperties SeatProperties { get; set; }

    }
    public static class ProductExtansion { 
        public static Product Clone(this Product product)
        {
                return new Product
                {
                    Id = product.Id,
                    Category = product.Category,
                    Name = product.Name,
                    BriefDescription = product.BriefDescription,
                    ShortDescription = product.ShortDescription,
                    Description = product.Description,
                    Rating = product.Rating,
                    Price = product.Price,
                    IsNew = product.IsNew,
                    DiscountPercentage = product.DiscountPercentage,
                    DiscountedPrice = product.DiscountedPrice,
                    SKU = product.SKU,
                    ProductImages = product.ProductImages
                };
            }
        public static Product Clone(this Product product, Func<Product, Product> alter)
        {
            var res = alter(product.Clone());
            return res;
        }
    }
    

}

