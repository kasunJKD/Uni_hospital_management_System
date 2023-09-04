using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Models;

namespace Uni_hospital.ViewModels
{
    public class TipsViewModel
    {
        public List<Tips> Tips { get; set; } = new List<Tips>();
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public TipsViewModel() { }

        public TipsViewModel(Tips app)
        {
            Id = app.Id;
            Description = app.Description;
            CreatedDate = app.CreatedDate;
            UpdatedDate = app.UpdatedDate;
        }

        public Tips ConvertViewModelToModel(TipsViewModel user)
        {
            return new Tips
            {
                Id = user.Id,
                Description = user.Description,
                CreatedDate= user.CreatedDate,
                UpdatedDate = user.UpdatedDate,
            };

        }
    }
}
