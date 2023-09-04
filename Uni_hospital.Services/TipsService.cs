using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Models;
using Uni_hospital.Repositories.Interfaces;
using Uni_hospital.Utilities;
using Uni_hospital.ViewModels;

namespace Uni_hospital.Services
{
    public class TipsService: ITipsService
    {
        private IUnitOfWork _unitOfWork;

        public TipsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateAvailability(TipsViewModel availability)
        {
            availability.CreatedDate= DateTime.Now;
            availability.UpdatedDate= DateTime.Now;
            var model = new TipsViewModel().ConvertViewModelToModel(availability);
            _unitOfWork.GenericRepository<Tips>().Add(model);
            _unitOfWork.Save();
        }

        public PagedResult<TipsViewModel> GetAll(int pageNumber, int pageSize)
        {
            var AppointmentViewModel = new TipsViewModel();
            int totalCount;
            List<TipsViewModel> usersList = new List<TipsViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Tips>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Tips>().GetAll().ToList().Count();

                usersList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<TipsViewModel>
            {
                Data = usersList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return result;
        }

        public TipsViewModel GetAvailabilitytById(int id)
        {
            var model = _unitOfWork.GenericRepository<Tips>().GetByKey(e => e.Id == id);
            var vm = new TipsViewModel(model);
            return vm;
        }

        public void UpdateAvailability(TipsViewModel availability)
        {
            var model = new TipsViewModel().ConvertViewModelToModel(availability);
            var ModelById = _unitOfWork.GenericRepository<Tips>().GetById(model.Id);
            ModelById.Description = availability.Description;
            ModelById.UpdatedDate = DateTime.Now;
            _unitOfWork.GenericRepository<Tips>().Update(ModelById);
            _unitOfWork.Save();
        }

        private List<TipsViewModel> ConvertModelToViewModelList(List<Tips> modelList)
        {
            return modelList.Select(x => new TipsViewModel(x)).ToList();
        }

        public void Delete (int id)
        {
            var model = _unitOfWork.GenericRepository<Tips>().GetById(id);
            _unitOfWork.GenericRepository<Tips>().Delete(model);
            _unitOfWork.Save();
        }
    }
}
