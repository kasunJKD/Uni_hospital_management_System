namespace Uni_hospital.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public DateTime CreatedTime { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }

}
