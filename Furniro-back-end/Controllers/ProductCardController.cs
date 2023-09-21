using Furniro.DataAccess.Models.Api.Response;
using Furniro_back_end.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api = Furniro.DataAccess.Models.Api;
namespace Furniro_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCardController : ControllerBase
    {
        private ProductCardRepository _repository;
        public ProductCardController(ProductCardRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ProductCards> Get([FromQuery]api.ProductFilter filter)
        {
            if(filter == null)
                return new ProductCards { Cards = await _repository.GetByFilterAsync(filter), Total = 0 };
            else
            {
                return new ProductCards { Cards = await _repository.GetByFilterAsync(filter), Total = await _repository.FilterCount(filter)};
            }
        }
    }
}
