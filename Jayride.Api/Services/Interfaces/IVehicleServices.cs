using Jayride.Api.Models;

namespace Jayride.Api.Services.Interfaces
{
    public interface IVehicleServices
    {
        public Task<List<VehicleModel>> getVehiclesBasedOnPassengers(int passengers);
    }
}
