using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni_hospital.Models
{
    public class Availability
    {
        public int Id { get; set; }
        public string DoctorId { get; set; }
        public ApplicationUser Doctor { get; set; }
        public DateTime Date { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public Zone zone { get; set; }
        public int Duration { get; set; }
        public Status Status { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }

   
}


namespace Uni_hospital.Models
{
    public enum Zone
    {
        AM,
        PM,
    }
}

namespace Uni_hospital.Models
{
    public enum Status
    {
        Available, Pending, Confirm
    }
}