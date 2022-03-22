using DebetCards.Models;
using Microsoft.AspNetCore.Mvc;

namespace DebetCards.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReadConfigController : Controller
    {
        private readonly IConfiguration _configuration;
        public ReadConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public ConfigClass GetConfig()
        {
            return _configuration.Get<ConfigClass>(); ;
        }
    }
}
