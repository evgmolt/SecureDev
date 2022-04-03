using ConsulServiceA.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsulServiceA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsulKeyController : ControllerBase
    {
        [HttpGet(Name = "GetDemoKey")]
        public async Task<ActionResult> Get()
        {
            var consulDemoKey = await ConsulKeyValueProvider.GetValueAsync<ConsulDemoKey>(key: "ConsulDemoKey");

            if (consulDemoKey != null && consulDemoKey.IsEnabled)
            {
                return Ok(consulDemoKey);
            }

            return Ok("ConsulDemoKey is null");
        }
    }
}