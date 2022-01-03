using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.WebApp.Models
{
    public class RoutesBwLandmarksModel
    {
        public int NoOfRoutes { get; set; }
        public IEnumerable<string> Routes { get; set; }

        public override string ToString()
        {
            return $"No of Routes are {NoOfRoutes} and The Routes are {string.Join("; ", Routes)}";
        }
    }
}
