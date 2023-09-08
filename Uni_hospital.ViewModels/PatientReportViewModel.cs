using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Models;

namespace Uni_hospital.ViewModels
{
    public class PatientReportViewModel
    {
        public List<PatientReport> PatientReport { get; set; } = new List<PatientReport>();
        public int Id { get; set; }
        public string? Diagnose { get; set; }
        public string? DoctorId { get; set; }
        public ApplicationUser? Doctor { get; set; }

        public string? PatientId { get; set; }
        public ApplicationUser? Patient { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public PatientReportViewModel() { }

        public PatientReportViewModel(PatientReport app)
        {
            Id = app.Id;
            Diagnose= app.Diagnose;
            DoctorId = app.DoctorId;
            PatientId = app.PatientId;
            Patient = app.Patient;
            CreatedDate = app.CreatedDate;
            UpdatedDate = app.UpdatedDate;
            
        }

        public PatientReport ConvertViewModelToModel(PatientReportViewModel app)
        {
            return new PatientReport
            {
                Id = app.Id,
                Diagnose= app.Diagnose,
                DoctorId= app.DoctorId,
                PatientId= app.PatientId,
                Patient = app.Patient,
                CreatedDate = app.CreatedDate,
                UpdatedDate = app.UpdatedDate,
        };
        }
    }
}
