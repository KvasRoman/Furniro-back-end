using Furniro.DataAccess.Models.DataAccess;
using Furniro_back_end.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Furniro_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private IRepository<ProductImage> _repository;
        public ProductImageController(IRepository<ProductImage> repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public IActionResult Post(string url, int index)
        {
            var productImage = new ProductImage()
            {
                Id = Guid.NewGuid(),
                OrderNumber = index,
                ProductId = null,
                Url = url
            };
            _repository.Add(productImage);
            return Ok(productImage.Id);
        }
    }
}
