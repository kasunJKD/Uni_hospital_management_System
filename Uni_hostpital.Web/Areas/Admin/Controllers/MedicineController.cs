using Microsoft.AspNetCore.Mvc;
using Uni_hospital.Services;
using Uni_hospital.ViewModels;

namespace Uni_hostpital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MedicineController : Controller
    {
        private IMedicineService _itipsservice;

        public MedicineController(IMedicineService itipsservice)
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
            var viewModel = _itipsservice.GetMedicinetById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(MedicineViewModel vm)
        {
            _itipsservice.Update(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MedicineViewModel vm)
        {
            _itipsservice.Create(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _itipsservice.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
