using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Utilities;
using Uni_hospital.ViewModels;

namespace Uni_hospital.Services
{
    public interface IApplicationUserService
    {
        PagedResult<ApplicationUserViewModel> GetAll(int PageNumber, int PageSize);
        PagedResult<ApplicationUserViewModel> GetAllDoctor(int PageNumber, int PageSize);
        PagedResult<ApplicationUserViewModel> GetAllPatient(int PageNumber, int PageSize);
        PagedResult<ApplicationUserViewModel> SearchDoctor(int PageNumber, int PageSize, string Name, int SpecialityId);
    }
}
