using Microsoft.AspNetCore.Mvc;
using Uni_hospital.Services;
using Uni_hospital.ViewModels;

namespace Uni_hostpital.Web.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class FeedBackController : Controller
    {
        private IFeedBackService _itipsservice;

        public FeedBackController(IFeedBackService itipsservice)
        {
            _itipsservice = itipsservice;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FeedBackViewModel vm)
        {
            _itipsservice.CreateAvailability(vm);
            return RedirectToAction("Index", "Home");
        }
    }
}
