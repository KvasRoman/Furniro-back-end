using Furniro.BusinessLogic.DefaultIfEmpty;
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
        private DefaultImagesConfiguration _defaultImageConfig;
        public ProductCardController(ProductCardRepository repository, DefaultImagesConfiguration defaultImageConfig)
        {
            _repository = repository;
            _defaultImageConfig = defaultImageConfig;
        }
        [HttpGet]
        public async Task<ProductCards> Get([FromQuery]api.ProductFilter filter)
        {

            var cards = await _repository.GetByFilterAsync(filter);
            foreach (var card in cards)
            {
                if(card.ImageUrl == null)
                    card.ImageUrl = _defaultImageConfig.ProductImage;
            }
            return new ProductCards { Cards = cards, Total = await _repository.FilterCount(filter)};
        }
    }
}
