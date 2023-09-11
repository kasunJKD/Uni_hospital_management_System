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
    public class PrescribedMedicineService : IPrescribedMedicineService
    {
        private IUnitOfWork _unitOfWork;

        public PrescribedMedicineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreatePrescribedMedicine(PrescribedMedicineViewModel availability)
        {
            var model = new PrescribedMedicineViewModel().ConvertViewModelToModel(availability);
            _unitOfWork.GenericRepository<PrescribedMedicine>().Add(model);
            _unitOfWork.Save();
        }

        public PagedResult<PrescribedMedicineViewModel> GetAll(int pageNumber, int pageSize)
        {
            var AppointmentViewModel = new PrescribedMedicineViewModel();
            int totalCount;
            List<PrescribedMedicineViewModel> usersList = new List<PrescribedMedicineViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<PrescribedMedicine>().GetAll(includeProperties: "Medicine, PatientReport")
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<PrescribedMedicine>().GetAll().ToList().Count();

                usersList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<PrescribedMedicineViewModel>
            {
                Data = usersList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return result;
        }

        public List<PrescribedMedicineViewModel> GetAllPrescribedMedicineByReportId(int reportId)
        {
            List<PrescribedMedicineViewModel> groupedUsersList = new List<PrescribedMedicineViewModel>();
            try
            {

                var includeProperties = "Medicine,PatientReport";
                var modelList = _unitOfWork.GenericRepository<PrescribedMedicine>()
                    .GetAll(filter:ava => ava.PatientReport.Id == reportId, includeProperties: includeProperties)
                    .ToList();

                groupedUsersList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            return groupedUsersList;
        }

        public PrescribedMedicineViewModel GetPrescribedMedicineById(int id)
        {
            var model = _unitOfWork.GenericRepository<PrescribedMedicine>().GetByKey(e => e.Id == id, includeProperties: "Medicine, PatientReport");
            var vm = new PrescribedMedicineViewModel(model);
            return vm;
        }

        public void UpdatePrescribedMedicine(PrescribedMedicineViewModel availability)
        {
            var model = new PrescribedMedicineViewModel().ConvertViewModelToModel(availability);
            var ModelById = _unitOfWork.GenericRepository<PrescribedMedicine>().GetById(model.Id);
            ModelById.DurationDays = availability.DurationDays;
            _unitOfWork.GenericRepository<PrescribedMedicine>().Update(ModelById);
            _unitOfWork.Save();
        }


        private List<PrescribedMedicineViewModel> ConvertModelToViewModelList(List<PrescribedMedicine> modelList)
        {
            return modelList.Select(x => new PrescribedMedicineViewModel(x)).ToList();
        }
    }
}
