using Jayride.Domain.DependencyInjection;
using Jayride.Domain.ObjectValue;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace Jayride.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        [HttpGet("{passengers}")]
        public async Task<ActionResult<IEnumerable<Listing>>> Get(int passengers)
        {
            try
            {
                var quote = await Dependencies.JayrideService.GetQuote();
                var listings = quote.listings.Where(x => x.vehicleType.maxPassengers >= passengers);
                listings = listings.OrderBy(x => x.GetTotalPrice(passengers));

                return Ok(listings);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
