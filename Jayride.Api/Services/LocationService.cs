
using System.Net.Http;
using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Jayride.Api.Services.Interfaces;
using Jayride.Api.Models;
using Jayride.Api.DataAccess;
using Jayride.Api.DataAccess.Entities;
using AutoMapper;

namespace Jayride.Api.Services
{
    public class LocationService : ILocationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        public LocationService(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;

        }

        public async Task<LocationModel?> getLocationByIp(string ipAddress)
        {

            var httpClient = _httpClientFactory.CreateClient();

            var httpResponseMessage = await httpClient.GetAsync(
            $"http://ip-api.com/json/{ipAddress}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                try
                {
                    var location = await JsonSerializer.DeserializeAsync<Location>(contentStream);
                    if (location != null)
                    {
                        LocationModel result =  _mapper.Map<LocationModel>(location);
                        return result;
                    }

                } catch (Exception ex)
                {
                    return null;
                }
                
            }
            return null;
        }

    }
}