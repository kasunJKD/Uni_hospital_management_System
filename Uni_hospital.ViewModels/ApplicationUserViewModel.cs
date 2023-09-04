using Uni_hospital.Models;

namespace Uni_hospital.ViewModels
{
    //admin prescribe meds to patients
    //add medicine create
    //create feedback
    //admin create patient report
    //get list of patient reports
    //check info in patient reports
    //create tips
    //show tips randomly
    public class ApplicationUserViewModel
    {
        public List<ApplicationUser> Doctors { get; set; } = new List<ApplicationUser>();
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? SpecialistId { get; set; }
        public string? SpecialistName { get; set; }
        public bool isDoctor { get; set; }
        public Gender Gender { get; set; }
        public string SearchName { get; set; }

        public ApplicationUserViewModel() { }

        public ApplicationUserViewModel(ApplicationUser user)
        {
            Id=user.Id;
            UserName = user.UserName;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            SpecialistId = user.SpecialityId;
            SpecialistName = user.Speciality.Name;
            isDoctor = user.IsDoctor;
            Gender = user.Gender;

        }

        public ApplicationUser ConvertViewModelToModel(ApplicationUserViewModel user)
        {
            return new ApplicationUser
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                SpecialityId = user.SpecialistId,
                IsDoctor = user.isDoctor,
                Gender = user.Gender

            };
              
        }
    }

}