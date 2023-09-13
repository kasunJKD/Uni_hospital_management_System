using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Uni_hospital.Services;
using Uni_hostpital.Web.Models;

namespace Uni_hostpital.Web.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ITipsService _itipsservice;
        public HomeController(ILogger<HomeController> logger, ITipsService itipsservice)
        {
            _logger = logger;
            _itipsservice = itipsservice;
        }

        public IActionResult Index()
        {
            var list = _itipsservice.GetAll(1, 100).Data;
            // Check if the list is not empty
            if (list.Count > 0)
            {
                // Use Random class to generate a random index within the list's bounds
                var random = new Random();
                int randomIndex = random.Next(0, list.Count);

                // Assign the randomly selected tip to ViewBag.randomTip
                ViewBag.randomTip = list[randomIndex];
            }
            else
            {
                // Handle the case where the list is empty
                ViewBag.randomTip = "No tips available.";
            }

            return View();
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