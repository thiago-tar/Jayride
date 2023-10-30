using Jayride.Domain.DependencyInjection;
using Jayride.Domain.ObjectValue;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jayride.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        [HttpGet("{ip}")]
        public async Task<ActionResult<IpLocation>> Get(string ip)
        {
            try
            {   
                var location = await Dependencies.IpStackService.GetLocation(ip);
                if (location == null) return NotFound();

                return Ok(location);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
