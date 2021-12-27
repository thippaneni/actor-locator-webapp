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
    }
}
