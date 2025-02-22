using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SteamKeyStore.Model.Utlity;
using SteamKeyStore.Services.Interfaces;

namespace SteamKeyStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaseController<T, TSearch> : ControllerBase where T : class where TSearch : class
    {
        protected readonly IService<T, TSearch> _service;
        protected readonly ILogger<BaseController<T, TSearch>> _logger;

        public BaseController(ILogger<BaseController<T, TSearch>> logger, IService<T, TSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet()]
        public virtual async Task<PagedResult<T>> Get([FromQuery] TSearch search)
        {
            return await _service.Get(search);
        }

        [HttpGet("{id}")]
        public virtual async Task<T> GetById(int id)
        {
            return await _service.GetById(id);
        }
    }
}
