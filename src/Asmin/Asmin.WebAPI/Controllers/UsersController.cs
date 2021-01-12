using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Asmin.Business.Abstract;
using Asmin.Core.Entities.Concrete;
using Asmin.Core.Extensions;
using Asmin.Entities.CustomEntities.Request.User;
using Asmin.Packages.JWT.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asmin.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(AsminTokenAuthFilter))]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("login")]
        [AsminIgnoreTokenAuthFilter]
        public IActionResult Login(UserLoginRequest request)
        {
            var checkUserLoginRequest = _userManager.Login(request);

            if (!checkUserLoginRequest.IsSuccess)
            {
                return BadRequest(checkUserLoginRequest);
            }

            return Ok(checkUserLoginRequest);
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var userDataResult = await _userManager.GetListAsync();

            if (!userDataResult.IsSuccess)
            {
                return BadRequest(userDataResult);
            }

            return Ok(userDataResult);
        }

        [HttpGet]
        [Route("{id}")]
        [TypeFilter(typeof(AsminTokenAuthFilter))]
        public async Task<IActionResult> GetById(int id)
        {
            var userDataResult = await _userManager.GetByIdAsync(id);

            if (!userDataResult.IsSuccess)
            {
                return BadRequest(userDataResult);
            }

            return Ok(userDataResult);
        }

        [HttpPost]
        public async Task<IActionResult> Add(InsertUserRequest insertUserRequest)
        {
            var checkUserAdded = await _userManager.AddAsync(insertUserRequest);

            if (!checkUserAdded.IsSuccess)
            {
                BadRequest(checkUserAdded);
            }

            return Ok(checkUserAdded);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserRequest updateUserRequest)
        {
            var checkUserUpdated = await _userManager.UpdateAsync(updateUserRequest);

            if (!checkUserUpdated.IsSuccess)
            {
                return BadRequest(checkUserUpdated);
            }

            return Ok(checkUserUpdated);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var checkUserRemoved = await _userManager.RemoveAsync(id);

            if (!checkUserRemoved.IsSuccess)
            {
                return BadRequest(checkUserRemoved);
            }

            return Ok(checkUserRemoved);
        }
    }
}