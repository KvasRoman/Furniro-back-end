using Furniro.DataAccess.Models.DataAccess;
using Furniro_back_end.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Furniro_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportRequestController : ControllerBase
    {
        private IRepository<SupportRequest> _repository;
        public SupportRequestController(IRepository<SupportRequest> repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public IActionResult Post(SupportRequest request)
        {
            
            try
            {
                request.Id = Guid.NewGuid();
                _repository.Add(request);
            }
            catch
            {
                return StatusCode(500);
            }
            return Ok();
        }
    }
}
