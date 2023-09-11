using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Models;
using Uni_hospital.Utilities;
using Uni_hospital.ViewModels;

namespace Uni_hospital.Services
{
    public interface IPatientReportService
    {
        PagedResult<PatientReportViewModel> GetAll(int pageNumber, int pageSize);
        PatientReportViewModel GetPatientReportById(int id);
        void CreatePatientReport(PatientReportViewModel availability);
        void UpdatePatientReport(PatientReportViewModel availability);
        void Delete(int id);
        PagedResult<PatientReportViewModel> GetAllReportsByPatientId(int pageNumber, int pageSize, string patientId);
    }
}
