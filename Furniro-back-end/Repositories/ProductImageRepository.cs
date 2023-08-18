using Furniro.DataAccess;
using Furniro.DataAccess.Models.DataAccess;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Furniro_back_end.Repositories
{
    public class ProductImageRepository : Repository<ProductImage>, IRepository<ProductImage>
    {

        public ProductImageRepository(FurniroDbContext dbContext) : base(dbContext)
        {
        }

        public void BindToProduct(IEnumerable<ProductImage> productImages, Product product)
        {
            foreach (var image in productImages)
            {
                image.ProductId = product.Id;
            }
            _dbContext.SaveChanges();
        }
    }
}
