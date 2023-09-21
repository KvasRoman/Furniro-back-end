using Furniro.DataAccess;
using api = Furniro.DataAccess.Models.Api;
using Furniro.DataAccess.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Furniro.BusinessLogic.DefaultIfEmpty;

namespace Furniro_back_end.Repositories
{
    public class ProductCardRepository
    {
        private FurniroDbContext _dbcontext;
        private DefaultImagesConfiguration _defaultImageConfig;
        public ProductCardRepository(FurniroDbContext dbContext, DefaultImagesConfiguration defaultImageConfig)
        {
            _dbcontext = dbContext;
            _defaultImageConfig = defaultImageConfig;
        }
        public async Task<IEnumerable<api.ProductCard>> GetAllAsync()
        {
            return await (from pc in _dbcontext.Set<Product>()
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
                    ).ToListAsync();
        }
        public async Task<IEnumerable<api.ProductCard>> GetByFilterAsync(api.ProductFilter filter)
        {
            var res = (from pc in _dbcontext.Set<Product>().Include(p => p.ProductImages)
                       select new api.ProductCard()
                       {
                           Id = pc.Id,
                           Name = pc.Name,
                           ShortDescription = pc.ShortDescription,
                           Price = pc.Price,
                           IsNew = pc.IsNew,
                           DiscountPercentage = pc.DiscountPercentage,
                           DiscountedPrice = pc.DiscountedPrice,
                           ImageUrl = pc.ProductImages.First().Url != null ? pc.ProductImages.First().Url : _defaultImageConfig.ProductImage
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


            return await res
                .Skip(filter.PageSize * filter.Page)
                .Take(filter.PageSize).ToListAsync();
        }
        public async Task<int> FilterCount(api.ProductFilter filter)
        {
            var res = (from pc in _dbcontext.Set<Product>().Include(p => p.ProductImages)
                       select new api.ProductCard()
                       {
                           Id = pc.Id,
                           Name = pc.Name,
                           ShortDescription = pc.ShortDescription,
                           Price = pc.Price,
                           IsNew = pc.IsNew,
                           DiscountPercentage = pc.DiscountPercentage,
                           DiscountedPrice = pc.DiscountedPrice,
                           ImageUrl = pc.ProductImages.First().Url != null ? pc.ProductImages.First().Url : _defaultImageConfig.ProductImage
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
            return await res.CountAsync();
        }
    }
}
