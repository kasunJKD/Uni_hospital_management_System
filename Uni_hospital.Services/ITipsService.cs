using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Utilities;
using Uni_hospital.ViewModels;

namespace Uni_hospital.Services
{
    public interface ITipsService
    {
        PagedResult<TipsViewModel> GetAll(int pageNumber, int pageSize);
        TipsViewModel GetAvailabilitytById(int id);
        void CreateAvailability(TipsViewModel availability);
        void UpdateAvailability(TipsViewModel availability);
        void Delete(int id);
    }
}
