using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Uni_hospital.ViewModels
{
    public class AvailabilityViewModel
    {
        public List<Availability> Availability { get; set; } = new List<Availability>();
        public int Id { get; set; }
        public string DoctorId { get; set; }
        public ApplicationUser Doctor { get; set; }
        public DateTime Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public Zone zone { get; set; }
        public Status Status { get; set; }

        public AvailabilityViewModel() { }

        public AvailabilityViewModel(Availability app)
        {
            Id= app.Id;
            DoctorId = app.DoctorId;
            Doctor = app.Doctor;
            Date = app.Date;
            StartTime = app.StartTime;
            zone = app.zone;
            Status = app.Status;
        }

        public Availability ConvertViewModelToModel(AvailabilityViewModel app)
        {
            return new Availability
            {
                Id= app.Id,
                DoctorId = app.DoctorId,
                Doctor = app.Doctor,
                Date = app.Date,
                StartTime = app.StartTime,
                zone = app.zone,
                Status = app.Status,
            };
        }
    }
}
