using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Models;

namespace Uni_hospital.ViewModels
{
    public class FeedBackViewModel
    {
        public List<Feedback> Feedback { get; set; } = new List<Feedback>();
        public int Id { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public DateTime CreatedTime { get; set; }

        public FeedBackViewModel() { }

        public FeedBackViewModel(Feedback app)
        {
            Id = app.Id;
            Description= app.Description;
            Rate = app.Rate;
            CreatedTime = app.CreatedTime;
        }

        public Feedback ConvertViewModelToModel(FeedBackViewModel app)
        {
            return new Feedback
            {
                Id = app.Id,
                Description= app.Description,
                Rate = app.Rate,
                CreatedTime = app.CreatedTime,
                 
            };
        }
    }
}
