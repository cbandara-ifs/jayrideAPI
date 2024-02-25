using AutoMapper;
using Jayride.Api.DataAccess;
using Jayride.Api.Models;

namespace Jayride.Api.profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile() 
        {
            CreateMap<Location, LocationModel>();

            CreateMap<LocationModel, Location>();
        }
    }
}
