﻿using System;
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
    public class AppointmentService : IAppointmentService
    {
        private IUnitOfWork _unitOfWork;

        public AppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int CreateAppointment(AppointmentViewModel appointment)
        {
            var lastAppointment =  _unitOfWork.GenericRepository<Appointment>().GetOneByList(
                filter: a => a.AvailabilityId == appointment.AvailablityId,
                orderBy: q => q.OrderByDescending(a => a.CreatedDate));

            int newAppointmentNumber = 1; // Default value for the first appointment

            if (lastAppointment.Result != null)
            {
                // Parse the last appointment number and increment it by 1
                var lastNumber = lastAppointment.Result;
                newAppointmentNumber = lastNumber.Number + 1;
            }
            else
            {
                newAppointmentNumber = 1;
            }
            var model = new AppointmentViewModel().ConvertViewModelToModel(appointment);
            model.Number = newAppointmentNumber;
            model.CreatedDate = DateTime.Now;
            model.UpdatedDate = DateTime.Now;
            _unitOfWork.GenericRepository<Appointment>().Add(model);
            _unitOfWork.Save();

            return model.Id;
        }

        public PagedResult<AppointmentViewModel> GetAll(int pageNumber, int pageSize)
        {
            var AppointmentViewModel = new AppointmentViewModel();
            int totalCount;
            List<AppointmentViewModel> usersList = new List<AppointmentViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Appointment>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Appointment>().GetAll().ToList().Count();

                usersList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<AppointmentViewModel>
            {
                Data = usersList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return result;
        }

        private List<AppointmentViewModel> ConvertModelToViewModelList(List<Appointment> modelList)
        {
            return modelList.Select(x => new AppointmentViewModel(x)).ToList();
        }

        public AppointmentViewModel GetAppointmentById(int id)
        {
            var model = _unitOfWork.GenericRepository<Appointment>().GetByKey(env=>env.Id==id, includeProperties: "Doctor, Patient, Doctor.Speciality, Availability");
            var vm = new AppointmentViewModel(model);
            return vm;
        }

        public List<AppointmentViewModel> GetAppointmentsByAvailabilityId(int availabilityId)
        {
            var appointments = _unitOfWork.GenericRepository<Appointment>()
                .GetAll(includeProperties: "Availability") // Assuming GetAll() retrieves all appointments
                .Where(appointment => appointment.Availability.Id == availabilityId)
                .ToList();

            var usersList = ConvertModelToViewModelList(appointments);

            return usersList;
        }
    }
}
