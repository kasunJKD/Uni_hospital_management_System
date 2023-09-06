using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Models;

namespace Uni_hospital.ViewModels
{
    public class MedicineViewModel
    {
        public List<Medicine> Feedback { get; set; } = new List<Medicine>();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Cost { get; set; }

        public MedicineViewModel() { }

        public MedicineViewModel(Medicine app)
        {
            Id = app.Id;
            Name= app.Name;
            Description = app.Description;
            Type = app.Type;
            Cost = app.Cost;
        }

        public Medicine ConvertViewModelToModel(MedicineViewModel app)
        {
            return new Medicine
            {
                Id = app.Id,
                Name= app.Name,
                Description= app.Description,
                Type = app.Type,
                Cost = app.Cost,

            };
        }
    }
}
