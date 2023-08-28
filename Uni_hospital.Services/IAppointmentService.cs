using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Utilities;
using Uni_hospital.ViewModels;

namespace Uni_hospital.Services
{
    public interface IAppointmentService
    {
        PagedResult<AppointmentViewModel>GetAll(int pageNumber, int pageSize);
        AppointmentViewModel GetAppointmentById(int id);
        void CreateAppointment(AppointmentViewModel appointment);
    }
}
