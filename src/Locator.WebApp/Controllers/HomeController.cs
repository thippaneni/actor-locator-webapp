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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
