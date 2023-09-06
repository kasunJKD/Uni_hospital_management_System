using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Utilities;
using Uni_hospital.ViewModels;

namespace Uni_hospital.Services
{
    public interface IMedicineService
    {
        PagedResult<MedicineViewModel> GetAll(int pageNumber, int pageSize);
        MedicineViewModel GetMedicinetById(int id);
        void Create(MedicineViewModel availability);
        void Delete(int id);
        void Update(MedicineViewModel availability);
    }
}
