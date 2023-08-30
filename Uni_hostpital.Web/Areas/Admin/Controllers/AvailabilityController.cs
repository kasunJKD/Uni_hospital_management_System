using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Uni_hospital.Models;
using Uni_hospital.Services;
using Uni_hospital.ViewModels;

namespace Uni_hostpital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AvailabilityController : Controller
    {
        
        private IAvailablityService _availablityService;
        private IApplicationUserService _applicationUserService;

        public AvailabilityController(IAvailablityService availablityService, IApplicationUserService applicationUserService)
        {
            _availablityService = availablityService;
            _applicationUserService= applicationUserService;
        }

        public IActionResult Index(int pageNumber=1, int pageSize=10)
        {
            return View(_availablityService.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _availablityService.GetAvailabilitytById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(AvailabilityViewModel vm)
        {
            _availablityService.UpdateAvailability(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            var doctors = _applicationUserService.GetAllDoctorListDropDown();
            var doctorList = doctors.Select(d => new {
                DoctorId = d.Id,
                FullName = $"{d.FirstName} {d.LastName}" // Concatenate first name and last name
            });

            // Get all the enum values as a list of SelectListItem
            var enumValues = Enum.GetValues(typeof(Status))
                                 .Cast<Status>()
                                 .Select(e => new SelectListItem
                                 {
                                     Value = e.ToString(), // Convert enum value to string
                                     Text = e.ToString() // Convert enum value to string
                                 })
                                 .ToList();
            // Get all the enum values as a list of SelectListItem
            var zoneVals = Enum.GetValues(typeof(Zone))
                                 .Cast<Zone>()
                                 .Select(e => new SelectListItem
                                 {
                                     Value = e.ToString(), // Convert enum value to string
                                     Text = e.ToString() // Convert enum value to string
                                 })
                                 .ToList();
            ViewBag.zone = new SelectList(zoneVals, "Value", "Text");
            ViewBag.status = new SelectList(enumValues, "Value", "Text");
            ViewBag.doctor = new SelectList(doctorList, "DoctorId", "FullName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(AvailabilityViewModel vm)
        {
            _availablityService.CreateAvailability(vm);
            return RedirectToAction("Index");
        }

       /* public IActionResult Delete(int id) 
        {
            _availablityService.Delete(id)
            return RedirectToAction("Index");
        }*/
    }
}
