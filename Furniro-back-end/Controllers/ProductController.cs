using Furniro.DataAccess.Models.DataAccess;
using api = Furniro.DataAccess.Models.Api;
using Furniro_back_end.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Furniro_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IRepository<Product> _repository;
        private ProductImageRepository _productImageRep;
        public ProductController(IRepository<Product> repository, ProductImageRepository productImageRep)
        {
            _repository = repository;
            _productImageRep = productImageRep;
        }
        [HttpGet]
        public async Task<Product> Get(Guid Id)
        {

            return await _repository.GetByIdAsync(Id);
        }
        [HttpPost]
        public async Task<IActionResult> Post(api.Product product)
        {
            var newProduct = new Product(product);
            await _repository.AddAsync(newProduct);
            await _productImageRep.BindToProductAsync(
                await _productImageRep.GetAllByAsync(pi => product.Images.Contains(pi.Id)),
                newProduct
            );
            return Ok();
        }
    }
}
