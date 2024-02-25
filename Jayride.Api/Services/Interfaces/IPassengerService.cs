using Jayride.Api.Models;

namespace Jayride.Api.Services.Interfaces
{
    public interface IPassengerService
    {
        public Task<PassengerModel> GetPassenger();
    }
}
