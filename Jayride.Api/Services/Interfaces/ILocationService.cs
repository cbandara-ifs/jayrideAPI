using Jayride.Api.Models;

namespace Jayride.Api.Services.Interfaces
{
    public interface ILocationService
    {
        public Task<LocationModel?> getLocationByIp(string ipAddress);
    }
}
