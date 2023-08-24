using Microsoft.AspNetCore.Mvc;
using Uni_hospital.Services;

namespace Uni_hostpital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private IApplicationUserService _userService;

        public UsersController(IApplicationUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index(int PageNumber=1, int PageSize=10)
        {
            return View(_userService.GetAll(PageNumber, PageSize));
        }

        public IActionResult AllDoctors(int PageNumber = 1, int PageSize = 10)
        {
            return View(_userService.GetAllDoctor(PageNumber, PageSize).Data);
        }

        public IActionResult AllPatients(int PageNumber = 1, int PageSize = 10)
        {
            return View(_userService.GetAllPatient(PageNumber, PageSize).Data);
        }
        public IActionResult SearchDoctors(int PageNumber = 1, int PageSize = 10, string SearchName = null, int SpecialId = 0)
        {
            return View(_userService.SearchDoctor(PageNumber, PageSize, SearchName, SpecialId).Data);
        }

    }
}
