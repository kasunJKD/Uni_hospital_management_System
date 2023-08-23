using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Repositories.Interfaces;
using Uni_hospital.Utilities;

namespace Uni_hospital.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private IUnitOfWork _unitOfWork;

        public ApplicationUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        PagedResult<ApplicationUserViewModel> IApplicationUserService.GetAll(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        PagedResult<ApplicationUserViewModel> IApplicationUserService.GetAllDoctor(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        PagedResult<ApplicationUserViewModel> IApplicationUserService.GetAllPatient(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        PagedResult<ApplicationUserViewModel> IApplicationUserService.SearchDoctor(int PageNumber, int PageSize, string Name, int SpecialityId)
        {
            throw new NotImplementedException();
        }
    }
}
