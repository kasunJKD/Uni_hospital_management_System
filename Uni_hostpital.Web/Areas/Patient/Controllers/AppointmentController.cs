using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Uni_hospital.Services;

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
            return View();
        }
    }
}
