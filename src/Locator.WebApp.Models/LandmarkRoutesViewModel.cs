using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.WebApp.Models
{
    public class LandmarkRoutesViewModel
    {
        public IEnumerable<LandmarkModel> Landmarks { get; set; } = new List<LandmarkModel>();
        public IEnumerable<RouteModel> Routes { get; set; } = new List<RouteModel>();
        public string StartLandmark { get; set; }
        public string EndLandmark { get; set; }
        public string ViaLandmarks { get; set; }
        public int? MaxStops { get; set; }
        public RoutesBwLandmarksModel RoutesBwLandmark { get; set; }

        public IEnumerable<int> Stops { get; set; } = new List<int>() { 0, 1, 2, 3, 4 };
    }
}
