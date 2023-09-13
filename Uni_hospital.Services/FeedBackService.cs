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
    public class FeedBackService:IFeedBackService
    {
        private IUnitOfWork _unitOfWork;

        public FeedBackService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateAvailability(FeedBackViewModel availability)
        {
            var model = new FeedBackViewModel().ConvertViewModelToModel(availability);
            _unitOfWork.GenericRepository<Feedback>().Add(model);
            _unitOfWork.Save();
        }

        public PagedResult<FeedBackViewModel> GetAll(int pageNumber, int pageSize)
        {
            var AppointmentViewModel = new FeedBackViewModel();
            int totalCount;
            List<FeedBackViewModel> usersList = new List<FeedBackViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Feedback>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Feedback>().GetAll().ToList().Count();

                usersList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<FeedBackViewModel>
            {
                Data = usersList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return result;
        }


        public FeedBackViewModel GetById(int id)
        {
            var model = _unitOfWork.GenericRepository<Feedback>().GetByKey(e => e.Id == id);
            var vm = new FeedBackViewModel(model);
            return vm;
        }

        private List<FeedBackViewModel> ConvertModelToViewModelList(List<Feedback> modelList)
        {
            return modelList.Select(x => new FeedBackViewModel(x)).ToList();
        }
    }
}
