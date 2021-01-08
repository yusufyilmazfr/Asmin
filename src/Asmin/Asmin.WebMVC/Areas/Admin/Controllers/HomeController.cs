using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asmin.Business.Abstract;
using Asmin.Core.Entities.Concrete;
using Asmin.Entities.CustomEntities.Request.User;
using Asmin.WebMVC.Constants;
using Asmin.WebMVC.Filters;
using Asmin.WebMVC.Services.Session;
using Microsoft.AspNetCore.Mvc;

namespace Asmin.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [TypeFilter(typeof(CheckSessionFilter))]
    public class HomeController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly ISessionService _sessionService;
        public User CurrentUser => _sessionService.GetObject<User>(SessionKey.CurrentUser);

        public HomeController(IUserManager userManager, ISessionService sessionService)
        {
            _userManager = userManager;
            _sessionService = sessionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnySessionFilter]
        public IActionResult Login()
        {
            if (CurrentUser != null)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        [AllowAnySessionFilter]
        public async IActionResult Login(UserLoginRequest user)
        {
            var checkUser = _userManager.Login(user);

            if (!checkUser.IsSuccess)
            {
                ModelState.AddModelError("Error", checkUser.Message);
                return View(user);
            }

            if (checkUser.Data == null)
            {
                ModelState.AddModelError("InvalidUser", "Invalid email or password.");
                return View(user);
            }

            _sessionService.SetObject(SessionKey.CurrentUser, checkUser.Data);

            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            _sessionService.Remove(SessionKey.CurrentUser);

            return RedirectToAction("Login");
        }
    }
}