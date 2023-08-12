using Furniro_back_end.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using Furniro.DataAccess.Models;
namespace Furniro_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private IRepository<Country> _repository;
        public CountryController(IRepository<Country> repository) { 
            _repository = repository;
        }
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return _repository.GetAll();
        }

    }
}
