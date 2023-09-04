using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using Uni_hospital.Services;

namespace Uni_hostpital.Web.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class HomeController : Controller
    {
        private ITipsService _itipsservice;

        public HomeController(ITipsService itipsservice)
        {
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
    }
}
