using Furniro.DataAccess;
using api = Furniro.DataAccess.Models.Api;
using Furniro.DataAccess.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Furniro_back_end.Repositories
{
    public class ProductCardRepository
    {
        private FurniroDbContext _dbcontext;
        public ProductCardRepository(FurniroDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public IEnumerable<api.ProductCard> GetAll()
        {
            return (from pc in _dbcontext.Set<Product>()
                    from pi in _dbcontext.Set<ProductImage>()
                    .Where(p => p.ProductId == pc.Id)
                    .OrderBy(p => p.OrderNumber)
                    .Take(1)
                    select new api.ProductCard()
                    {
                        Id = pc.Id,
                        Name = pc.Name,
                        ShortDescription = pc.ShortDescription,
                        Price = pc.Price,
                        IsNew = pc.IsNew,
                        DiscountPercentage = pc.DiscountPercentage,
                        DiscountedPrice = pc.DiscountedPrice,
                        ImageUrl = pi.Url
                    }
                    );
        }
        public IEnumerable<api.ProductCard> GetByFilter(api.ProductFilter filter)
        {
            var res = (from pc in _dbcontext.Set<Product>()
                       from pi in _dbcontext.Set<ProductImage>()
                       .Where(p => p.ProductId == pc.Id)
                       .OrderBy(p => p.OrderNumber)
                       .Take(1)
                       select new api.ProductCard()
                       {
                           Id = pc.Id,
                           Name = pc.Name,
                           ShortDescription = pc.ShortDescription,
                           Price = pc.Price,
                           IsNew = pc.IsNew,
                           DiscountPercentage = pc.DiscountPercentage,
                           DiscountedPrice = pc.DiscountedPrice,
                           ImageUrl = pi.Url
                       }
                    );
            switch (filter.OrderBy)
            {
                case "NameAsc": res = res.OrderBy(e => e.Name); break;
                case "NameDesc": res = res.OrderBy(e => e.Name); break;
                case "PriceAsc": res = res.OrderBy(e => e.Price); break;
                case "PriceDesc": res = res.OrderByDescending(e => e.Price); break;
                default: break;
            }


            return res
                .Skip(filter.PageSize * filter.Page)
                .Take(filter.PageSize);
        }
    }
}
