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
    public class PatientReportService: IPatientReportService
    {
        private IUnitOfWork _unitOfWork;

        public PatientReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreatePatientReport(PatientReportViewModel availability)
        {
            availability.CreatedDate = DateTime.Now;
            availability.UpdatedDate = DateTime.Now;
            var model = new PatientReportViewModel().ConvertViewModelToModel(availability);
            _unitOfWork.GenericRepository<PatientReport>().Add(model);
            _unitOfWork.Save();
        }

        public PagedResult<PatientReportViewModel> GetAll(int pageNumber, int pageSize)
        {
            var AppointmentViewModel = new PatientReportViewModel();
            int totalCount;
            List<PatientReportViewModel> usersList = new List<PatientReportViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<PatientReport>().GetAll(includeProperties: "Doctor,Patient")
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<PatientReport>().GetAll().ToList().Count();

                usersList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<PatientReportViewModel>
            {
                Data = usersList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return result;
        }

        public PatientReportViewModel GetPatientReportById(int id)
        {
            var model = _unitOfWork.GenericRepository<PatientReport>().GetByKey(e => e.Id == id, includeProperties:"Doctor,Patient");
            var vm = new PatientReportViewModel(model);
            return vm;
        }

        public void UpdatePatientReport(PatientReportViewModel availability)
        {
            var model = new PatientReportViewModel().ConvertViewModelToModel(availability);
            var ModelById = _unitOfWork.GenericRepository<PatientReport>().GetByKey(e => e.Id == model.Id, includeProperties: "Doctor,Patient");
            ModelById.DoctorId = availability.DoctorId;
            ModelById.UpdatedDate = DateTime.Now;
            ModelById.PatientId = availability.PatientId;
            _unitOfWork.GenericRepository<PatientReport>().Update(ModelById);
            _unitOfWork.Save();
        }

        private List<PatientReportViewModel> ConvertModelToViewModelList(List<PatientReport> modelList)
        {
            return modelList.Select(x => new PatientReportViewModel(x)).ToList();
        }

        public void Delete(int id)
        {
            var model = _unitOfWork.GenericRepository<PatientReport>().GetById(id);
            _unitOfWork.GenericRepository<PatientReport>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<PatientReportViewModel> GetAllReportsByPatientId(int pageNumber, int pageSize, string patientId)
        {
            var AppointmentViewModel = new PatientReportViewModel();
            int totalCount;
            List<PatientReportViewModel> usersList = new List<PatientReportViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<PatientReport>().GetAll(includeProperties: "Doctor,Patient", filter:ava => ava.PatientId == patientId)
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<PatientReport>().GetAll().ToList().Count();

                usersList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<PatientReportViewModel>
            {
                Data = usersList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return result;
        }
    }
}
