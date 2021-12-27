using AutoMapper;
using Locator.WebApp.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Locator.Api.Contracts.Responses;

namespace Locator.WebApp.ServiceClients
{
    public class LocatorApiClient : ILocatorApiClient
    {
        private readonly string _baseAddress;
        private readonly HttpClient _client;
        private readonly IMapper _mapper;

        public LocatorApiClient(IConfiguration configuration, HttpClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;

            _baseAddress = configuration.GetSection("LocatorApi").GetValue<string>("BaseUrl");
        }
        public async Task<IEnumerable<LandmarkModel>> GetAllLandMarksAsync()
        {
            var response = await _client.GetAsync(new Uri($"{_baseAddress}/Landmark/GetAll"));
            var landmarksResponse = await response.Content.ReadAsAsync<GetAllLandmarksResponse>();
            var result = landmarksResponse.Data.ToList().Select(d => _mapper.Map<LandmarkModel>(d)).ToList();
            return result;
        }

        public async Task<IEnumerable<RouteModel>> GetAllRoutesAsync()
        {
            var response = await _client.GetAsync(new Uri($"{_baseAddress}/Route/GetAll"));
            var routessResponse = await response.Content.ReadAsAsync<GetAllRoutesResponse>();
            var result = routessResponse.Data.ToList().Select(d => _mapper.Map<RouteModel>(d)).ToList();
            return result;
        }
    }
}
