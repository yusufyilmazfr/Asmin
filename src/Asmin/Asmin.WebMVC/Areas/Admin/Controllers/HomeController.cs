using System.Threading.Tasks;
using Asmin.Core.Entities.Concrete;
using Asmin.Entities.CustomEntities.Request.User;
using Asmin.WebMVC.Constants;
using Asmin.WebMVC.Filters;
using Asmin.WebMVC.Services.Rest.UserService;
using Asmin.WebMVC.Services.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asmin.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [TypeFilter(typeof(CheckSessionFilter))]
    public class HomeController : Controller
    {
        private readonly ISessionService _sessionService;
        private readonly IUserApiService _userApiService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public User CurrentUser => _sessionService.Get<User>(SessionKey.CurrentUser);

        public HomeController(ISessionService sessionService, IUserApiService userApiService, IHttpContextAccessor httpContextAccessor)
        {
            _sessionService = sessionService;
            _userApiService = userApiService;
            _httpContextAccessor = httpContextAccessor;
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
        public async Task<IActionResult> Login(UserLoginRequest userLoginRequest)
        {
            var checkUser = await _userApiService.LoginAsync(userLoginRequest);

            if (!checkUser.IsSuccess)
            {
                ModelState.AddModelError("Error", checkUser.Message);
                return View(userLoginRequest);
            }

            if (checkUser.Data == null)
            {
                ModelState.AddModelError("InvalidUser", "Invalid email or password.");
                return View(userLoginRequest);
            }

            var cookieOptions = new CookieOptions
            {
                // Set the secure flag, which Chrome's changes will require for SameSite none.
                // Note this will also require you to be running on HTTPS
                Secure = true,

                // Set the cookie to HTTP only which is good practice unless you really do need
                // to access it client side in scripts.
                HttpOnly = true,

                // Add the SameSite attribute, this will emit the attribute with a value of none.
                // To not emit the attribute at all set the SameSite property to SameSiteMode.Unspecified.
                SameSite = SameSiteMode.None
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Append("token", checkUser.Data.TokenInformation.Token);

            _sessionService.Set(SessionKey.CurrentUser, checkUser.Data);

            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("token");
            _sessionService.Remove(SessionKey.CurrentUser);

            return RedirectToAction("Login");
        }
    }
}