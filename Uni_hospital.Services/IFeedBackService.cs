using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Utilities;
using Uni_hospital.ViewModels;

namespace Uni_hospital.Services
{
    public interface IFeedBackService
    {
        PagedResult<FeedBackViewModel> GetAll(int pageNumber, int pageSize);
        FeedBackViewModel GetById(int id);
        void CreateAvailability(FeedBackViewModel availability);
    }
}
