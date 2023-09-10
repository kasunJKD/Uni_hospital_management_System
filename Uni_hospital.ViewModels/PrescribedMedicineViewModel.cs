using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Models;

namespace Uni_hospital.ViewModels
{
    public class PrescribedMedicineViewModel
    {
        public List<PrescribedMedicine> PrescribedMedicine { get; set; } = new List<PrescribedMedicine>();
        public int Id { get; set; }
        public int MedicineId { get; set; }
        public Medicine? Medicine { get; set; }
        public int PatientReportId { get; set; }
        public PatientReport? PatientReport { get; set; }
        public MedicineIntakeZone MedicineIntakeZone { get; set; }
        public int DurationDays { get; set; }

        public PrescribedMedicineViewModel() { }

        public PrescribedMedicineViewModel(PrescribedMedicine app)
        {
            Id = app.Id;
            Medicine= app.Medicine;
            PatientReport = app.PatientReport;
            MedicineIntakeZone= app.MedicineIntakeZone;
            DurationDays = app.DurationDays;
            MedicineId = app.Medicine.Id;
            PatientReportId = app.PatientReport.Id;
        }

        public PrescribedMedicine ConvertViewModelToModel(PrescribedMedicineViewModel app)
        {
            return new PrescribedMedicine
            {
                Id = app.Id,
                Medicine = app.Medicine,
                PatientReport = app.PatientReport,
                MedicineIntakeZone = app.MedicineIntakeZone,
                DurationDays = app.DurationDays,
                MedicineId = app.MedicineId,
                PatientReportId= app.PatientReportId
        };
        }
    }
}
