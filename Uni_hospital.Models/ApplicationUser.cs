
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni_hospital.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Email {get; set;}
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }

        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; }

        public bool IsDoctor { get; set; }
        public string PictureUri { get; set; }
        [NotMapped]
        public ICollection<Appointment> Appointments { get; set; }
        [NotMapped]
        public ICollection<PatientReport> PatientReports { get; set; }
        public ICollection<Availability> Availabilities { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}

namespace Uni_hospital.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
