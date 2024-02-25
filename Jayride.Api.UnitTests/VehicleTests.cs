using Jayride.Api.DataAccess.Entities;
using Jayride.Api.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jayride.Api.UnitTests
{
    public class VehicleTests
    {
        private readonly Mock<IHttpClientFactory> _mockHttpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly VehicleListing vehicleListing;

        public VehicleTests()
        {
           _mockHttpClientFactory = new Mock<IHttpClientFactory>();

            var inMemorySettings = new Dictionary<string, string?> {
                {"quoteRequest:url", "https://jayridechallengeapi.azurewebsites.net/api/QuoteRequest"},
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            vehicleListing = new VehicleListing
            {
                from = "Sydney Airport (SYD), T1 International Terminal",
                to = "46 Church Street, Parramatta NSW, Australia",
                listings = new List<Listings>
                {
                    new Listings
                    {
                        name = "Listing 1",
                        pricePerPassenger = 32.14,
                        vehicleType = new VehicleType
                        {
                            name = "SUV",
                            maxPassengers = 5
                        }
                    },
                    new Listings
                    {
                        name = "Listing 2",
                        pricePerPassenger = 73.68,
                        vehicleType = new VehicleType
                        {
                            name = "Sedan",
                            maxPassengers = 3
                        }
                    }
                }
            };
        }

        [Fact]
        public async Task shouldReturnVehiclesBasedOnPassengers()
        {
            int passengers = 4;
            var vehicleListingJSON = "{\"from\":\"Sydney Airport (SYD), T1 International Terminal\",\"to\":\"46 Church Street, Parramatta NSW, Australia\",\"listings\":[{\"name\":\"Listing 1\",\"pricePerPassenger\":32.14,\"vehicleType\":{\"name\":\"SUV\",\"maxPassengers\":5}},{\"name\":\"Listing 2\",\"pricePerPassenger\":73.68,\"vehicleType\":{\"name\":\"Sedan\",\"maxPassengers\":3}}]}";
            
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var httpClient = new HttpClient(mockHttpMessageHandler.Object);

            _mockHttpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(httpClient);

            mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(vehicleListingJSON)
            }) ;

            VehicleServices processor = new VehicleServices(_mockHttpClientFactory.Object, _configuration);

            var result = await processor.getVehiclesBasedOnPassengers(passengers);

            Assert.NotNull(result);
            Assert.Equal(vehicleListing.listings[0].pricePerPassenger*passengers, result[0].totalPrice);
            Assert.Equal(vehicleListing.listings[0].name, result[0].name);
            Assert.Equal(vehicleListing.listings[0].pricePerPassenger, result[0].pricePerPassenger);
            Assert.Equal(vehicleListing.listings[0].vehicleType.maxPassengers, result[0].maxPassengers);

        }
    }
}
