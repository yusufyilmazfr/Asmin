using System.Threading.Tasks;
using Asmin.WebMVC.Filters;
using Asmin.WebMVC.Services.Rest.UserService;
using Microsoft.AspNetCore.Mvc;

namespace Asmin.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [TypeFilter(typeof(CheckSessionFilter))]
    public class UserController : Controller
    {
        private readonly IUserApiService _userApiService;

        public UserController(IUserApiService userApiService)
        {
            _userApiService = userApiService;
        }

        public async Task<IActionResult> Index()
        {
            var usersResult = await _userApiService.GetListAsync();

            return View(usersResult.Data);
        }
    }
}