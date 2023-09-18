using Furniro.DataAccess.Models.DataAccess.Properties;
using Furniro_back_end.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Furniro.BusinessLogic.Extansions;
using Furniro.DataAccess.Models.DataAccess;

namespace Furniro_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComparisonController : ControllerBase
    {
        ProductRepository _productRepository;
        public ComparisonController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts(Guid[] ids, string cagegory)
        {
            var res = _productRepository.GetWithPropertiesAsync(ids, cagegory);
            return await res;
        }
    }
}
