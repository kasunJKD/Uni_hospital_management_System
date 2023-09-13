using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Uni_hospital.Models;
using Uni_hospital.Services;

namespace Uni_hostpital.Web.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class PatientReportController : Controller
    {
        private IPatientReportService _patientReportService;
        private IPrescribedMedicineService _prescribedMedicineService;
        private IMedicineService _medicineService;
        private IApplicationUserService _applicationUserService;

        public PatientReportController(IPatientReportService patientReportService, IPrescribedMedicineService prescribedMedicineService, IMedicineService medicineService, IApplicationUserService applicationUserService)
        {
            _patientReportService = patientReportService;
            _prescribedMedicineService = prescribedMedicineService;
            _medicineService = medicineService;
            _applicationUserService = applicationUserService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            //get logged in UserData
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userData = _applicationUserService.GetUsertById(userId);
            return View(_patientReportService.GetAllReportsByPatientId(pageNumber, pageSize,  userData.Id));
        }

        [HttpGet]
        public IActionResult MedsList(int id)
        {
            var presmeds = _prescribedMedicineService.GetAllPrescribedMedicineByReportId(id);
            return View(presmeds);
        }
    }
}
