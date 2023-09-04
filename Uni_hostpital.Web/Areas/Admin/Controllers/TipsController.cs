using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Uni_hospital.Models;
using Uni_hospital.Services;
using Uni_hospital.ViewModels;

namespace Uni_hostpital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TipsController : Controller
    {
        private ITipsService _itipsservice;

        public TipsController(ITipsService itipsservice)
        {
            _itipsservice = itipsservice;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_itipsservice.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _itipsservice.GetAvailabilitytById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(TipsViewModel vm)
        {
            _itipsservice.UpdateAvailability(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TipsViewModel vm)
        {
            _itipsservice.CreateAvailability(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _itipsservice.Delete(id);
             return RedirectToAction("Index");
        }
    }
}
