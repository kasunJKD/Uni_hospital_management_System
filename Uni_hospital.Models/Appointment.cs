using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni_hospital.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}
        public string? Description { get; set; }
        public string DoctorId { get; set; }
        public ApplicationUser Doctor { get; set; }
        public string PatientId { get; set; }
        public ApplicationUser Patient { get; set; }
        public int AvailabilityId { get; set;}
        public Availability Availability { get; set; }
    }
}
