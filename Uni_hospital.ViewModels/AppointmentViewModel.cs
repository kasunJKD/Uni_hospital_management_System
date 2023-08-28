using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Models;

namespace Uni_hospital.ViewModels
{
    public class AppointmentViewModel
    {
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public int Number { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? Description { get; set; }
        public string? DoctorFirstName { get; set; }
        public string? DoctorLastName { get; set; }
        public string? PatientFirstName { get; set; }
        public string? PatientLastName { get; set; }
        public string SpecialityName { get; set; }
        public string? SpecialityDescription { get; set;}
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public int AvailablityId { get; set; }

        public AppointmentViewModel() { }

        public AppointmentViewModel(Appointment app)
        {
            Number = app.Number;
            CreatedDate = app.CreatedDate;
            UpdatedDate = app.UpdatedDate;
            Description = app.Description;
            DoctorFirstName = app.Doctor.FirstName;
            DoctorLastName = app.Doctor.LastName;
            PatientFirstName = app.Patient.FirstName;
            PatientLastName = app.Patient.LastName;
            SpecialityName = app.Doctor.Speciality.Name;
            SpecialityDescription=app.Doctor.Speciality.Description;
            PatientId= app.Patient.Id;
            DoctorId= app.Doctor.Id;
            AvailablityId = app.AvailablityId;
            
        }

        public Appointment ConvertViewModelToModel(AppointmentViewModel app)
        {
            return new Appointment
            {
                Number = app.Number,
                CreatedDate = app.CreatedDate,
                UpdatedDate = app.UpdatedDate,
                Description = app.Description,
                DoctorId=app.DoctorId,
                PatientId=app.PatientId,
                AvailablityId=app.AvailablityId,
        };

        }
    }


}
