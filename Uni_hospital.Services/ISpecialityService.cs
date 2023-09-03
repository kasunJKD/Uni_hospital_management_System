using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.ViewModels;

namespace Uni_hospital.Services
{
    public interface ISpecialityService
    {
        List<SpecialityViewModel> GetAll();
    }
}
