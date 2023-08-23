using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni_hospital.Models
{
    public class Speciality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

    }
}
