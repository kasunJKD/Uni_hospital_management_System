using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Utilities;
using Uni_hospital.ViewModels;

namespace Uni_hospital.Services
{
    public interface IAvailablityService
    {
        List<AvailabilityViewModel> GetAllActiveAvailabilityById(string id);
        PagedResult<AvailabilityViewModel> GetAll(int pageNumber, int pageSize);
        AvailabilityViewModel GetAvailabilitytById(int id);
        void CreateAvailability(AvailabilityViewModel availability);
        void UpdateAvailability(AvailabilityViewModel availability);
    }
}
