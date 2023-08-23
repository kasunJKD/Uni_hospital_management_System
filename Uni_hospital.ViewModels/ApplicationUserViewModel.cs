using Uni_hospital.Models;

namespace Uni_hospital.ViewModels
{
    public class ApplicationUserViewModel
    {
        public List<ApplicationUser> Doctors { get; set; } = new List<ApplicationUser>();
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SpecialistId { get; set; }
        public string SpecialistName { get; set; }
        public bool isDoctor { get; set; }
        public Gender Gender { get; set; }

        public ApplicationUserViewModel() { }

        public ApplicationUserViewModel(ApplicationUser user)
        {
            UserName = user.UserName;
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
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                SpecialityId = user.SpecialistId,
                IsDoctor = user.isDoctor,
                Gender = user.Gender

            };
              
        }
    }
}