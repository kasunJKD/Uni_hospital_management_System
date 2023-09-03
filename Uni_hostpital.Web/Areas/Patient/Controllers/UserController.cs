using Microsoft.AspNetCore.Mvc;
using Uni_hospital.Services;
using Uni_hospital.ViewModels;

namespace Uni_hostpital.Web.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class UserController : Controller
    {
        private IApplicationUserService _userService;

        public UserController(IApplicationUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index(int PageNumber = 1, int PageSize = 10)
        {
            return View(_userService.GetAllDoctor(PageNumber, PageSize).Data);
        }
        [HttpPost]
        public IActionResult Index(int PageNumber = 1, int PageSize = 10, string SearchName = null, int SpecialId = 0)
        {
            return View(_userService.SearchDoctor(PageNumber, PageSize, SearchName, SpecialId).Data);
        }

        [HttpGet]
        public IActionResult Info(string id)
        {
            var viewModel = _userService.GetUsertById(id);
            return View(viewModel);
        }
    }
}
