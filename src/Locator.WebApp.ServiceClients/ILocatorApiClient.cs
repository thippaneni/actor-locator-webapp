using Locator.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locator.WebApp.ServiceClients
{
    public interface ILocatorApiClient
    {
        Task<IEnumerable<LandmarkModel>> GetAllLandMarksAsync();

        Task<IEnumerable<RouteModel>> GetAllRoutesAsync();

        Task<string> GetDistanceBWLandmarks(string startLandmark, string endLandmark, IEnumerable<string> viaLandmarkCodes);

        Task<RoutesBwLandmarksModel> GetRoutesBWLandmarks(string startLandmark, string endLandmark, int? noOfStops);
    }
}
