using Furniro.DataAccess.Models.DataAccess;
using api = Furniro.DataAccess.Models.Api;
using Furniro_back_end.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Furniro.BusinessLogic.DefaultIfEmpty;

namespace Furniro_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IRepository<Product> _repository;
        private ProductImageRepository _productImageRep;
        private DefaultImagesConfiguration _defaultImagesConfiguration;
        public ProductController(IRepository<Product> repository, ProductImageRepository productImageRep, DefaultImagesConfiguration defaultImageConfig)
        {
            _repository = repository;
            _productImageRep = productImageRep;
            _defaultImagesConfiguration = defaultImageConfig;
        }
        [HttpGet]
        public async Task<Product> Get(Guid Id)
        {
            var product = await _repository.GetByIdAsync(Id);
            if (product.ProductImages.Count == 0)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage() { Url = _defaultImagesConfiguration.ProductImage }
                };
            };
            return product;
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
