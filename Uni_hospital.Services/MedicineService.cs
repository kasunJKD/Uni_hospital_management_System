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
    public class MedicineService: IMedicineService
    {
        private IUnitOfWork _unitOfWork;

        public MedicineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(MedicineViewModel availability)
        {
            var model = new MedicineViewModel().ConvertViewModelToModel(availability);
            _unitOfWork.GenericRepository<Medicine>().Add(model);
            _unitOfWork.Save();
        }

        public PagedResult<MedicineViewModel> GetAll(int pageNumber, int pageSize)
        {
            var AppointmentViewModel = new MedicineViewModel();
            int totalCount;
            List<MedicineViewModel> usersList = new List<MedicineViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Medicine>().GetAll(includeProperties: "Doctor.Speciality")
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Medicine>().GetAll().ToList().Count();

                usersList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<MedicineViewModel>
            {
                Data = usersList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return result;
        }

        public MedicineViewModel GetMedicinetById(int id)
        {
            var model = _unitOfWork.GenericRepository<Medicine>().GetByKey(e => e.Id == id);
            var vm = new MedicineViewModel(model);
            return vm;
        }

        public void Update(MedicineViewModel availability)
        {
            var model = new MedicineViewModel().ConvertViewModelToModel(availability);
            var ModelById = _unitOfWork.GenericRepository<Medicine>().GetById(model.Id);
            _unitOfWork.GenericRepository<Medicine>().Update(ModelById);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var ModelById = _unitOfWork.GenericRepository<Medicine>().GetById(id);
            _unitOfWork.GenericRepository<Medicine>().Delete(ModelById);
            _unitOfWork.Save();
        }

        private List<MedicineViewModel> ConvertModelToViewModelList(List<Medicine> modelList)
        {
            return modelList.Select(x => new MedicineViewModel(x)).ToList();
        }
    }
}
