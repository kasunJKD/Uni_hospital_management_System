using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Uni_hospital.Models;
using Uni_hospital.Services;
using Uni_hospital.ViewModels;

namespace Uni_hostpital.Web.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class AppointmentController : Controller
    {
        //Doctor search name - get a list
        //Specializationlist
        //search button

        //doctor profile [channel]

        //doctor availability list [book] + [active appointments]
        private IAvailablityService _availabilityService;
        private ISpecialityService _specialityService;
        private IApplicationUserService _applicationUserService;

        public AppointmentController(IAvailablityService availabilityService, ISpecialityService specialityService, IApplicationUserService applicationUserService)
        {
            _availabilityService = availabilityService;
            _specialityService = specialityService;
            _applicationUserService = applicationUserService;
        }
        public IActionResult Index()
        {
            var sp = _specialityService.GetAll().Skip(1).ToList();
            var doctors = _applicationUserService.GetAllDoctorListDropDown();
            var doctorList = doctors.Select(d => new {
                DoctorId = d.Id,
                FullName = $"{d.FirstName} {d.LastName}" // Concatenate first name and last name
            });
            ViewBag.speciality = new SelectList(sp, "Id", "Name");
            ViewBag.doctor = new SelectList(doctorList, "DoctorId", "FullName");
            return View();
        }

        public IActionResult GetAvailabilityInfo(string DoctorId, int SpecialityId = 0)
        {
            var availList = _availabilityService.GetAllActiveAvailabilityById(DoctorId, SpecialityId);

            return View(availList);
        }

        [HttpGet]
        public IActionResult CreateAppointment()
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

/*        [HttpPost]
        public IActionResult CreateAppointment(AvailabilityViewModel vm)
        {
            _availablityService.CreateAvailability(vm);
            return RedirectToAction("Index");
        }*/
    }
}
