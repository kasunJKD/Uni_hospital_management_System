using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Uni_hospital.ViewModels
{
    public class SpecialityViewModel
    {
        public List<Speciality> Availability { get; set; } = new List<Speciality>();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public SpecialityViewModel() { }

        public SpecialityViewModel(Speciality app)
        {
            Id = app.Id;
            Name = app.Name;
        }

        public Speciality ConvertViewModelToModel(SpecialityViewModel user)
        {
            return new Speciality
            {
                Id = user.Id,
                Name = user.Name,
            };

        }
    }
}
