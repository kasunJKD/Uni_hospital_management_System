using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Models;
using Uni_hospital.Repositories.Interfaces;
using Uni_hospital.Utilities;
using Uni_hospital.ViewModels;

namespace Uni_hospital.Services
{
    public class AvailabilityService:IAvailablityService
    {
        private IUnitOfWork _unitOfWork;

        public AvailabilityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateAvailability(AvailabilityViewModel availability)
        {
            var model = new AvailabilityViewModel().ConvertViewModelToModel(availability);
            _unitOfWork.GenericRepository<Availability>().Add(model);
            _unitOfWork.Save();
        }

        public PagedResult<AvailabilityViewModel> GetAll(int pageNumber, int pageSize)
        {
            var AppointmentViewModel = new AvailabilityViewModel();
            int totalCount;
            List<AvailabilityViewModel> usersList = new List<AvailabilityViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Availability>().GetAll(includeProperties: "Doctor")
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Availability>().GetAll().ToList().Count();

                usersList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<AvailabilityViewModel>
            {
                Data = usersList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return result;
        }

        public List<AvailabilityViewModel> GetAllActiveAvailabilityById(string id)
        {
            List<AvailabilityViewModel> usersList = new List<AvailabilityViewModel>();
            try
            {

                var modelList = _unitOfWork.GenericRepository<Availability>().GetAll(
                filter: a => a.DoctorId == id && a.Status == 0,
                orderBy: q => q.OrderBy(a => a.StartTime)).ToList();

                usersList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            return usersList;
        }

        public AvailabilityViewModel GetAvailabilitytById(int id)
        {
            var model = _unitOfWork.GenericRepository<Availability>().GetById(id);
            var vm = new AvailabilityViewModel(model);
            return vm;
        }

        public void UpdateAvailability(AvailabilityViewModel availability)
        {
            var model = new AvailabilityViewModel().ConvertViewModelToModel(availability);
            var ModelById = _unitOfWork.GenericRepository<Availability>().GetById(model.Id);
            ModelById.Status= availability.Status;
            _unitOfWork.GenericRepository<Availability>().Update(ModelById);
            _unitOfWork.Save();
        }

        private List<AvailabilityViewModel> ConvertModelToViewModelList(List<Availability> modelList)
        {
            return modelList.Select(x => new AvailabilityViewModel(x)).ToList();
        }
    }
}
