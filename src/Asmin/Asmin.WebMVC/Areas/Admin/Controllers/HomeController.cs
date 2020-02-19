using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asmin.Business.Abstract;
using Asmin.Entities.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Asmin.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private IUserManager _userManager;

        public HomeController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(UserLoginDto user)
        {
            var checkUser = await _userManager.Login(user);

            if (!checkUser.IsSuccess)
            {
                ModelState.AddModelError("", checkUser.Message);
                return View();
            }

            if (checkUser.Data == null)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View();
            }

            return View();
        }
    }
}