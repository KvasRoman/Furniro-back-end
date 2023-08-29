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
        public Product Get(Guid Id)
        {
            return (from pc in _repository.GetAll().Where(p => p.Id == Id)
                    select pc).First();
        }
        [HttpPost]
        public IActionResult Post(api.Product product)
        {
            var newProduct = new Product(product);
            _repository.Add(newProduct);
            _productImageRep.BindToProduct(
                _productImageRep.GetAll().Where(pi => product.Images.Contains(pi.Id)),
                newProduct
                );
            return Ok();
        }
    }
}
