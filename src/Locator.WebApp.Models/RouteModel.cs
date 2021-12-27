using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.WebApp.Models
{
    public class RouteModel
    {
        public LandmarkModel StartLandmark { get; set; }
        public LandmarkModel EndLandmark { get; set; }
        public int Distance { get; set; }
        public string RouteCode { get; set; }
        public Guid Id { get; set; }
    }
}
