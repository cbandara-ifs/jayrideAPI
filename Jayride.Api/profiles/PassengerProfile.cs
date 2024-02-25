using AutoMapper;
using Jayride.Api.DataAccess.Entities;
using Jayride.Api.Models;

namespace Jayride.Api.profiles
{
    public class PassengerProfile : Profile
    {
        public PassengerProfile() 
        {
            CreateMap<Passenger,PassengerModel>();

            CreateMap<PassengerModel, Passenger>();
        }
    }
}
