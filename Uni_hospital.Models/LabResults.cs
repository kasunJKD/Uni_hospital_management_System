namespace Uni_hospital.Models
{
    public class LabResults
    {
        public int Id { get; set; }
        public LabType LabTypes { get; set; }
        public string Description { get; set; }
        public PatientReport PatientReport { get; set; }
    }
}

namespace Uni_hospital.Models
{
    public enum LabType
    {
        Full_blood_report,
        ECG,
    }
}
