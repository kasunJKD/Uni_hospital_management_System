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
    public class ApplicationUserService : IApplicationUserService
    {
        private IUnitOfWork _unitOfWork;

        public ApplicationUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PagedResult<ApplicationUserViewModel> GetAll(int PageNumber, int PageSize)
        {
            var ApplicationUserViewModel = new ApplicationUserViewModel();
            int totalCount;
            List<ApplicationUserViewModel> usersList = new List<ApplicationUserViewModel>();
            try
            {
                int ExcludeRecords = (PageSize * PageNumber) - PageSize;

                var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(includeProperties: "Speciality")
                    .Skip(ExcludeRecords).Take(PageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll().ToList().Count();

                usersList = ConvertModelToViewModelList(modelList);
            }
            catch(Exception)
            {
                throw;
            }
            var result = new PagedResult<ApplicationUserViewModel>
            {
                Data = usersList,
                TotalItems = totalCount,
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            return result;
        }

        private List<ApplicationUserViewModel> ConvertModelToViewModelList(List<ApplicationUser> modelList)
        {
            return modelList.Select(x => new ApplicationUserViewModel(x)).ToList();
        }

        public PagedResult<ApplicationUserViewModel> GetAllDoctor(int PageNumber, int PageSize)
        {
            var ApplicationUserViewModel = new ApplicationUserViewModel();
            int totalCount;
            List<ApplicationUserViewModel> usersList = new List<ApplicationUserViewModel>();
            try
            {
                int ExcludeRecords = (PageSize * PageNumber) - PageSize;

                var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x=>x.IsDoctor==true, includeProperties: "Speciality")
                    .Skip(ExcludeRecords).Take(PageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x=>x.IsDoctor==true).ToList().Count();

                usersList = ConvertModelToViewModelList(modelList);

                // Check if the usersList is empty, and return an empty result if true
                if (usersList.Count == 0)
                {
                    return new PagedResult<ApplicationUserViewModel>
                    {
                        Data = usersList,
                        TotalItems = 0, // TotalItems should be 0 for an empty result
                        PageNumber = PageNumber,
                        PageSize = PageSize
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<ApplicationUserViewModel>
            {
                Data = usersList,
                TotalItems = totalCount,
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            return result;
        }

        public PagedResult<ApplicationUserViewModel> GetAllPatient(int PageNumber, int PageSize)
        {
            var ApplicationUserViewModel = new ApplicationUserViewModel();
            int totalCount;
            List<ApplicationUserViewModel> usersList = new List<ApplicationUserViewModel>();
            try
            {
                int ExcludeRecords = (PageSize * PageNumber) - PageSize;

                var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsDoctor == false && x.UserName != "Admin", includeProperties: "Speciality")
                    .Skip(ExcludeRecords).Take(PageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsDoctor == false).ToList().Count();

                usersList = ConvertModelToViewModelList(modelList);

                // Check if the usersList is empty, and return an empty result if true
                if (usersList.Count == 0)
                {
                    return new PagedResult<ApplicationUserViewModel>
                    {
                        Data = usersList,
                        TotalItems = 0, // TotalItems should be 0 for an empty result
                        PageNumber = PageNumber,
                        PageSize = PageSize
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<ApplicationUserViewModel>
            {
                Data = usersList,
                TotalItems = totalCount,
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            return result;
        }

        public PagedResult<ApplicationUserViewModel> SearchDoctor(int PageNumber, int PageSize, string Name, int SpecialityId)
        {
            int totalCount;
            List<ApplicationUserViewModel> usersList = new List<ApplicationUserViewModel>();
            try
            {
                int ExcludeRecords = (PageSize * PageNumber) - PageSize;

                // Construct the predicate based on searchName and SpecialityId
                Expression<Func<ApplicationUser, bool>> searchPredicate = null;
                if (!string.IsNullOrEmpty(Name) && SpecialityId != 0)
                {
                    searchPredicate = user => user.IsDoctor &&
                        (user.FirstName.Contains(Name) || user.LastName.Contains(Name)) &&
                        user.SpecialityId == SpecialityId;
                }
                else if (!string.IsNullOrEmpty(Name))
                {
                    searchPredicate = user => user.IsDoctor &&
                        (user.FirstName.Contains(Name) || user.LastName.Contains(Name));
                }
                else if (SpecialityId != 0)
                {
                    searchPredicate = user => user.IsDoctor && user.SpecialityId == SpecialityId;
                }
                else
                {
                    searchPredicate = user => user.IsDoctor;
                }

                var modelList = _unitOfWork.GenericRepository<ApplicationUser>()
                    .GetAll(searchPredicate, includeProperties: "Speciality")
                    .Skip(ExcludeRecords)
                    .Take(PageSize)
                    .ToList();

                totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(searchPredicate).ToList().Count();

                usersList = ConvertModelToViewModelList(modelList);

                // Rest of your code...
            }
            catch (Exception)
            {
                throw;
            }

            var result = new PagedResult<ApplicationUserViewModel>
            {
                Data = usersList,
                TotalItems = totalCount,
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            return result;
        }

        public List<ApplicationUserViewModel> GetAllDoctorListDropDown()
        {
            List<ApplicationUserViewModel> usersList = new List<ApplicationUserViewModel>();
            try
            {

                var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsDoctor == true, includeProperties: "Speciality").ToList();

                usersList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }


            return usersList;
        }

        public ApplicationUserViewModel GetUsertById(string id)
        {
            var model = _unitOfWork.GenericRepository<ApplicationUser>().GetByKey(e => e.Id == id, includeProperties: "Speciality");
            var vm = new ApplicationUserViewModel(model);
            return vm;
        }
    }
}
