using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Uni_hospital.Models;
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
            var doctorList = meds.Data.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = $"{d.Name}" // Concatenate first name and last name
            });
            // Get all the enum values as a list of SelectListItem
            var enumValues = Enum.GetValues(typeof(MedicineIntakeZone))
                                 .Cast<MedicineIntakeZone>()
                                 .Select(e => new SelectListItem
                                 {
                                     Value = e.ToString(), // Convert enum value to string
                                     Text = e.ToString() // Convert enum value to string
                                 })
                                 .ToList();
            ViewBag.presmeds = presmeds;
            ViewBag.doctorList = doctorList;
            ViewBag.enumValues = enumValues;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddMeds(int PatientReportId, int medicineName, int DurationDays, int medicineIntakeZone)
        {
            PrescribedMedicineViewModel vm = new PrescribedMedicineViewModel();
            vm.PatientReportId= PatientReportId;
            vm.MedicineId= medicineName;
            vm.DurationDays= DurationDays;

            // Convert the integer to the corresponding enum value
            if (Enum.IsDefined(typeof(MedicineIntakeZone), medicineIntakeZone))
            {
                vm.MedicineIntakeZone = (MedicineIntakeZone)medicineIntakeZone;
            }


            _prescribedMedicineService.CreatePrescribedMedicine(vm);
            return RedirectToAction("Index");
        }


    }
}
