using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Asmin.WebMVC.Services.Rest.UserService;

namespace Asmin.WebMVC.Areas.Admin.Components
{
    public class RegisteredUsersCount : ViewComponent
    {
        private readonly IUserApiService _userApiService;

        public RegisteredUsersCount(IUserApiService userApiService)
        {
            _userApiService = userApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var usersCountResult = await _userApiService.GetCountAsync();

            return View(usersCountResult.Data);
        }
    }
}
