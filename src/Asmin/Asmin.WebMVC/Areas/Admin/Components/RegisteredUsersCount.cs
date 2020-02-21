using Asmin.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asmin.WebMVC.Areas.Admin.Components
{
    public class RegisteredUsersCount : ViewComponent
    {
        private IUserManager _userManager;

        public RegisteredUsersCount(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var usersCountResul = await _userManager.GetCountAsync();

            return View(usersCountResul.Data);
        }
    }
}
