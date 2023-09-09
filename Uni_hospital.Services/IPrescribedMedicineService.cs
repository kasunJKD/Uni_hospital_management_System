using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Utilities;
using Uni_hospital.ViewModels;

namespace Uni_hospital.Services
{
    public interface IPrescribedMedicineService
    {
        List<PrescribedMedicineViewModel> GetAllPrescribedMedicineByReportId(int userId);
        PagedResult<PrescribedMedicineViewModel> GetAll(int pageNumber, int pageSize);
        PrescribedMedicineViewModel GetPrescribedMedicineById(int id);
        void CreatePrescribedMedicine(PrescribedMedicineViewModel availability);
        void UpdatePrescribedMedicine(PrescribedMedicineViewModel availability);
    }
}
