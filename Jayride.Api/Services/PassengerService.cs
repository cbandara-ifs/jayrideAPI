
using Jayride.Api.Models;
using Jayride.Api.DataAccess.Entities;
using Jayride.Api.Services.Interfaces;
using Jayride.Api.DataAccess.Repositories.Interfaces;
using AutoMapper;

namespace Jayride.Api.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _repository;
        private readonly IMapper _mapper;

        public PassengerService(IPassengerRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PassengerModel> GetPassenger()
        {
            var passenger = await _repository.getPassenger();

            var model = _mapper.Map<PassengerModel>(passenger);

            return model;
        }
    }
}