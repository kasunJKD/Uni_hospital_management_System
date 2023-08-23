using Microsoft.AspNetCore.Mvc;

namespace Uni_hostpital.Web.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
