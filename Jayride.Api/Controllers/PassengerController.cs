using Jayride.Api.DataAccess.Entities;
using Jayride.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jayride.Api.Controllers
{
    [Route("api/[controller]")]
    public class PassengerController : Controller
    {
        public readonly IPassengerService _passengerService;

        public PassengerController(IPassengerService passengerService) {
            _passengerService = passengerService;
        }

        [HttpGet]
        public async Task<IActionResult> getPassenger()
        {
            var result = await _passengerService.GetPassenger();

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
