using Jayride.Api.DataAccess.Entities;
using Jayride.Api.DataAccess.Repositories.Interfaces;
using Jayride.Api.Models;
using Jayride.Api.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using AutoMapper;


namespace Jayride.Api.UnitTests
{
    public class PassengerTest
    {
        private readonly Mock<IPassengerRepository> _mockPassengerRepo;
        private readonly Mock<IMapper> _mapper;
        private Passenger request;

        public PassengerTest() 
        {
            _mockPassengerRepo = new Mock<IPassengerRepository>();
            _mapper = new Mock<IMapper>();

            request = new Passenger
            {
                Name = "test",
                Phone = "test"
            };
        }
        [Fact]
        public async void shouldReturnPassengerWithGetPassengerReq()
        {

            PassengerModel pModel = new PassengerModel
            {
                Name = "test",
                Phone = "test"
            };

            _mockPassengerRepo.Setup(x => x.getPassenger()).ReturnsAsync(request);

            _mapper.Setup(mapper => mapper.Map<PassengerModel>(request)).Returns(pModel);

            PassengerService processor = new PassengerService(_mockPassengerRepo.Object, _mapper.Object);

            PassengerModel result = await processor.GetPassenger();

            Assert.NotNull(result);
            Assert.Equal(request.Name, result.Name);
            Assert.Equal(request.Phone, result.Phone);

        }
    }
}
