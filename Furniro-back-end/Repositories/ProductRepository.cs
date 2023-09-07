using Furniro.DataAccess;
using Furniro.DataAccess.Models.DataAccess;
using Microsoft.EntityFrameworkCore;
using api = Furniro.DataAccess.Models.Api;
namespace Furniro_back_end.Repositories
{
    public class ProductRepository : Repository<Product>, IRepository<Product>
    {
        public ProductRepository(FurniroDbContext dbContext) : base(dbContext)
        {
        }
        public void Add(api.Product product)
        {
            _dbContext.Set<Product>().Add(new Product(product));
            _dbContext.SaveChanges();
        }
        override public Product GetById(Guid id)
        {
            return (from pc in _dbContext.Set<Product>().Include(p => p.ProductImages).Where(p => p.Id == id)
             select pc).First();
        }
    }
}
