using Microsoft.AspNetCore.Mvc;
using Uni_hospital.Services;
using Uni_hospital.ViewModels;

namespace Uni_hostpital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PatientReportController : Controller
    {
        private IPatientReportService _patientReportService;
        private IPrescribedMedicineService _prescribedMedicineService;
        private IMedicineService _medicineService;

        public PatientReportController(IPatientReportService patientReportService, IPrescribedMedicineService prescribedMedicineService, IMedicineService medicineService)
        {
            _patientReportService = patientReportService;
            _prescribedMedicineService = prescribedMedicineService;
            _medicineService = medicineService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_patientReportService.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _patientReportService.GetPatientReportById(id);
            var presmeds = _prescribedMedicineService.GetAllPrescribedMedicineByReportId(id);
            var meds = _medicineService.GetAll(1, 100);
            ViewBag.presmeds = presmeds;
            ViewBag.meds = meds;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddMeds(PrescribedMedicineViewModel vm)
        {
            _prescribedMedicineService.CreatePrescribedMedicine(vm);
            return View();
        }
    }
}
