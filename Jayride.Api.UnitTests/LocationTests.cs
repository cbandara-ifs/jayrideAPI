using Castle.Core.Configuration;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Jayride.Api.Services;
using AutoMapper;
using Jayride.Api.Models;
using Jayride.Api.DataAccess;


namespace Jayride.Api.UnitTests
{
    public class LocationTests
    {
        private readonly Mock<IHttpClientFactory> _mockHttpClientFactory;
        private readonly IMapper _mapper;

        public LocationTests() 
        {
            _mockHttpClientFactory = new Mock<IHttpClientFactory>();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Location, LocationModel>();
            });

            _mapper = configuration.CreateMapper();

        }
        [Fact]
        public async Task shouldReturnLocation()
        {
            var ipAddress = "180.150.37.173";

            var expectedLocation = new Location
            {
                city = "Melbourne",
                lat = -37.8159,
                lon = 144.9669
            };

            var mockLocationModel = new LocationModel
            {
                city = expectedLocation.city,
                lat = expectedLocation.lat,
                lon = expectedLocation.lon
            };
            
            var httpClient = new HttpClient();

            _mockHttpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(httpClient);

            LocationService processor = new LocationService(_mockHttpClientFactory.Object, _mapper);

            var result = await processor.getLocationByIp(ipAddress);

            Assert.Equal(mockLocationModel.city, result.city);
        }
    }
}
