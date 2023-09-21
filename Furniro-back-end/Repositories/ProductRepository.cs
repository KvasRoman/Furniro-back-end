using Furniro.BusinessLogic.DefaultIfEmpty;
using Furniro.BusinessLogic.Extansions;
using Furniro.DataAccess;
using Furniro.DataAccess.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api = Furniro.DataAccess.Models.Api;
namespace Furniro_back_end.Repositories
{
    public class ProductRepository : Repository<Product>, IRepository<Product>
    {
        DefaultImagesConfiguration _defaultImageConfiguration;
        public ProductRepository(FurniroDbContext dbContext, DefaultImagesConfiguration defaultImageConfiguration) : base(dbContext)
        {
            _defaultImageConfiguration = defaultImageConfiguration;
        }
        public void Add(api.Product product)
        {
            _dbContext.Set<Product>().Add(new Product(product));
            _dbContext.SaveChanges();
        }
        public override Product GetById(Guid id)
        {
            return (from pc in _dbContext.Set<Product>().Include(p => p.ProductImages).Where(p => p.Id == id)
                    select pc).First();
        }
        public override async Task<Product> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<Product>().Include(p => p.ProductImages).Where(p => p.Id == id)
                .FirstAsync();
        }
        public override async void AddAsync(Product entity)
        {
            await _dbContext.Set<Product>().AddAsync(entity);
        }
        public IEnumerable<Product> GetWithProperties(Guid[] ids, string propertiesType)
        {
            var products = _dbContext.Set<Product>().Include(p => p.ProductImages);
            switch (propertiesType)
            {
                case "seat": return products.Include(p => p.SeatProperties).Where(p => ids.Has(p.Id)); break;
                default: break;
            }
            return null;
        }
        
        public async Task<IEnumerable<Product>> GetWithPropertiesAsync(Guid[] ids, string propertiesType)
        {
            var products = _dbContext.Set<Product>().Include(p => p.ProductImages);
            switch (propertiesType)
            {
                case "seat": return await products.Include(p => p.SeatProperties).Where(p => ids.Has(p.Id)).ToListAsync(); break;
                default: break;
            }
            return null;
        }

    }
}
