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
        public async Task<IEnumerable<api.ProductCard>> Get([FromQuery]api.ProductFilter filter)
        {
            if(filter == null)
                return await _repository.GetAllAsync();
            else
            {
                return await _repository.GetByFilterAsync(filter);
            }
        }
    }
}
