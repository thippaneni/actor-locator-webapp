using AutoMapper;
using Locator.WebApp.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Locator.Api.Contracts.Responses;
using Newtonsoft.Json;
using Locator.Api.Contracts.Requests;
using System.Text;

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
        public async Task<string> GetDistanceBWLandmarks(string startLandmark, string endLandmark, IEnumerable<string> viaLandmarkCodes)
        {
            var requestModel = new GetDistanceBwLandmarksRequest() {
                StatingLanmarkCode = startLandmark,
                EndingLanmarkCode = endLandmark,
                ViaLandmarkCodes = viaLandmarkCodes
            };

            var jsonModel = JsonConvert.SerializeObject(requestModel);
            var response = await _client.PostAsync(new Uri($"{_baseAddress}/Landmark/GetDistanceBwLandmarks"),
                new StringContent(jsonModel, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var result = await response.Content.ReadAsAsync<GetDistanceBwLandmarksResponse>().ConfigureAwait(false);
            return result.Disatnce;
        }

        public async Task<RoutesBwLandmarksModel> GetRoutesBWLandmarks(string startLandmark, string endLandmark, int? noOfStops)
        {
            var requestModel = new GetNoOfRoutesBwLandmarksRequest()
            {
                StatingLanmarkCode = startLandmark,
                EndingLanmarkCode = endLandmark,
                MaxStops = noOfStops
            };

            var jsonModel = JsonConvert.SerializeObject(requestModel);
            var response = await _client.PostAsync(new Uri($"{_baseAddress}/Route/GetNoOfRoutesBwLandmarks"),
                new StringContent(jsonModel, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var result = await response.Content.ReadAsAsync<GetNoOfRoutesBwLandmarksResponse>().ConfigureAwait(false);
            return new RoutesBwLandmarksModel() { NoOfRoutes = result.NoOfRoutes, Routes = result.Routes };
        }
    }
}
