using Furniro.DataAccess;
using Furniro.DataAccess.Models.DataAccess;
using api = Furniro.DataAccess.Models.Api;
namespace Furniro_back_end.Repositories
{
    public class ProductRepository : Repository<Product>, IRepository<Product>
    {
        public ProductRepository(FurniroDbContext dbContext) : base(dbContext)
        {
        }
        void Add(api.Product product)
        {
            _dbContext.Set<Product>().Add(new Product(product));
            _dbContext.SaveChanges();
        }
    }
}
