using Jayride.Api.Models;
using Jayride.Api.Services;
using Jayride.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jayride.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleServices _vehicleServices;

        public VehicleController(IVehicleServices vehicleServices)
        {
            _vehicleServices = vehicleServices;
        }

        [HttpGet]
        public async Task<List<VehicleModel>> getVehiclesBasedOnPassengers(int passengers)
        {
            var result = await _vehicleServices.getVehiclesBasedOnPassengers(passengers);

            return result;
        }
    }
}
