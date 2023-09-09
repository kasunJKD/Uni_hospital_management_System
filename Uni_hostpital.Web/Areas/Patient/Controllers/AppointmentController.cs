using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
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
        private IAppointmentService _appointmentService;

        //create patient report when creating appointment
        private IPatientReportService _patientReportService;

        public AppointmentController(IAvailablityService availabilityService, ISpecialityService specialityService, IApplicationUserService applicationUserService, IAppointmentService appointmentService, IPatientReportService patientReportService)
        {
            _availabilityService = availabilityService;
            _specialityService = specialityService;
            _applicationUserService = applicationUserService;
            _appointmentService = appointmentService;
            _patientReportService = patientReportService;

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
        [Authorize]
        public IActionResult CreateAppointment(int id)
        {
            //get current availabilityData
            var viewModel = _availabilityService.GetAvailabilitytById(id);
            //get logged in UserData
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userData = _applicationUserService.GetUsertById(userId);
            if (userData != null)
            {
                ViewBag.loggedUserData = userData;
            }
            
            //get appointment by id (availabilityId)
            //count them
            //show it
            var count = _appointmentService.GetAppointmentsByAvailabilityId(id).Count();
            ViewBag.appointmentCount = count;
            ViewBag.AvailibilityId = id;
            ViewBag.viewModel = viewModel;
            return View();
        }

        [HttpPost]
        public IActionResult CreateAppointment(AppointmentViewModel vm)
        {
            int id = _appointmentService.CreateAppointment(vm);
            PatientReportViewModel viewModel= new PatientReportViewModel();
            viewModel.Id = id;
            viewModel.PatientId = vm.PatientId;
            viewModel.DoctorId = vm.DoctorId;
            viewModel.CreatedDate = DateTime.Now;
            viewModel.UpdatedDate = DateTime.Now;
            _patientReportService.CreatePatientReport(viewModel);
            // Store appointmentId in TempData
            TempData["CreatedAppointmentId"] = id;
            return RedirectToAction("GetCreatedAppointmentInfo");
        }

        public IActionResult GetCreatedAppointmentInfo()
        {
            AppointmentViewModel viewModel = new AppointmentViewModel();
            // Retrieve appointmentId from TempData
            if (TempData.TryGetValue("CreatedAppointmentId", out object appointmentIdObj) && appointmentIdObj is int appointmentId)
            {
                viewModel = _appointmentService.GetAppointmentById(appointmentId);
            }

            return View(viewModel);
        }
    }
}
