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
    }
}
