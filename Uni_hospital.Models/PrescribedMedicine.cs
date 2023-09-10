using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni_hospital.Models
{
    public class PrescribedMedicine
    {
        public int Id { get; set; }
        public int MedicineId { get; set; }
        public Medicine? Medicine { get; set; }
        public int PatientReportId { get; set; }
        public PatientReport? PatientReport { get; set; }
        public MedicineIntakeZone MedicineIntakeZone { get; set; }
        public int DurationDays { get; set; }
    }
}

namespace Uni_hospital.Models
{
    public enum MedicineIntakeZone
    {
        AM,
        PM,
    }
}
