using Azure.Core;
using Jayride.Api.Models;
using Jayride.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jayride.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService) {
            _locationService = locationService;
        } 
        [HttpGet]
        public async Task<LocationModel> getLocationByIp(string ip)
        {
            var result = await _locationService.getLocationByIp(ip);

            return result;
        }
    }
}
