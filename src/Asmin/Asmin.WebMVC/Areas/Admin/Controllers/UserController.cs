using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asmin.Business.Abstract;
using Asmin.WebMVC.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Asmin.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [CheckSessionFilter]
        public async Task<IActionResult> Index()
        {
            var usersResult = await _userManager.GetListAsync();
            return View(usersResult.Data);
        }
    }
}