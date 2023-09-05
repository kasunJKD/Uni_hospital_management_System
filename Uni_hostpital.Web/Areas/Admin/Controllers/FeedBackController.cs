using Microsoft.AspNetCore.Mvc;
using Uni_hospital.Services;
using Uni_hospital.ViewModels;

namespace Uni_hostpital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeedBackController : Controller
    {
        private IFeedBackService _itipsservice;

        public FeedBackController(IFeedBackService itipsservice)
        {
            _itipsservice = itipsservice;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_itipsservice.GetAll(pageNumber, pageSize));
        }

        public IActionResult Info(int id)
        {
            var viewModel = _itipsservice.GetById(id);
            return View(viewModel);
        }

    }
}
