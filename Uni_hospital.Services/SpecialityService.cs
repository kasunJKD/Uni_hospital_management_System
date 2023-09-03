using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Models;
using Uni_hospital.Repositories.Interfaces;
using Uni_hospital.Utilities;
using Uni_hospital.ViewModels;

namespace Uni_hospital.Services
{
    public class SpecialityService: ISpecialityService
    {
        private IUnitOfWork _unitOfWork;

        public SpecialityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<SpecialityViewModel> GetAll()
        {
            var AppointmentViewModel = new AvailabilityViewModel();
            int totalCount;
            List<SpecialityViewModel> usersList = new List<SpecialityViewModel>();
            try
            {

                var modelList = _unitOfWork.GenericRepository<Speciality>().GetAll().ToList();

                usersList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }

            return usersList;
        }
        private List<SpecialityViewModel> ConvertModelToViewModelList(List<Speciality> modelList)
        {
            return modelList.Select(x => new SpecialityViewModel(x)).ToList();
        }
    }
}
