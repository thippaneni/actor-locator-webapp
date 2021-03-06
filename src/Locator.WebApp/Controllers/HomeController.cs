using Locator.WebApp.Models;
using Locator.WebApp.ServiceClients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Locator.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILocatorApiClient _apiClinet;

        public HomeController(ILogger<HomeController> logger, ILocatorApiClient apiClinet)
        {
            _logger = logger;
            _apiClinet = apiClinet;
        }

        public async Task<IActionResult> Index()
        {
            var landmarks = await _apiClinet.GetAllLandMarksAsync();
            var routes = await _apiClinet.GetAllRoutesAsync();
            var data = new LandmarkRoutesViewModel() { Landmarks = landmarks, Routes = routes };            
            return View(data);
        }

        public IActionResult Privacy()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DistanceBWLandmarks(LandmarkRoutesViewModel model)
        {
            string Distance = string.Empty;
            if (model != null)
            {
                var viaLandmarks = new List<string>();
                if (!string.IsNullOrEmpty(model.ViaLandmarks))
                {
                    viaLandmarks = model.ViaLandmarks.Split(",").ToList();
                }
                Distance = await _apiClinet.GetDistanceBWLandmarks(model.StartLandmark, model.EndLandmark, viaLandmarks);
            }
            ViewData["APIResult"] = $"Distance BW Landmarks - {model.StartLandmark} and {model.EndLandmark} via {model.ViaLandmarks} Landmarks is {Distance} ";
            return View("Privacy");            
        }

        [HttpPost]
        public async Task<IActionResult> RoutesBWLandmarks(LandmarkRoutesViewModel model)
        {
            RoutesBwLandmarksModel result = null;
            if (model != null)
            {
                result = await _apiClinet.GetRoutesBWLandmarks(model.StartLandmark, model.EndLandmark, model.MaxStops);
            }
            var apiResult = $"Routes BW Landmarks - {model.StartLandmark} and {model.EndLandmark} having {model.MaxStops} max stops: \r\n  {result?.ToString()} ";
            ViewData["APIResult"] = apiResult;
            return View("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
