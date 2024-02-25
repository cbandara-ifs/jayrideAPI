using Jayride.Api.DataAccess.Entities;
using Jayride.Api.Models;
using Jayride.Api.Services.Interfaces;
using System.Text.Json;

namespace Jayride.Api.Services
{
    public class VehicleServices :IVehicleServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public VehicleServices(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        public async Task<List<VehicleModel>> getVehiclesBasedOnPassengers(int passengers)
        {
            using var httpClient = _httpClientFactory.CreateClient();
            var jayrideUrl = _config.GetValue<string>("quoteRequest:url");

            var httpResponseMessage = await httpClient.GetAsync(jayrideUrl);

            using var contentStream =
                await httpResponseMessage.Content.ReadAsStreamAsync();

            var vehicleList = await JsonSerializer.DeserializeAsync
                <VehicleListing>(contentStream);

            var filteredResult = vehicleList.listings
                .Where(x => x.vehicleType.maxPassengers >= passengers)
                .OrderBy(a => a.pricePerPassenger * passengers)
                .Select(y => new VehicleModel
                {
                    name = y.name,
                    totalPrice = y.pricePerPassenger * passengers,
                    pricePerPassenger = y.pricePerPassenger,
                    maxPassengers = y.vehicleType.maxPassengers
                })
                .ToList();

            return filteredResult;

        }
    }
}