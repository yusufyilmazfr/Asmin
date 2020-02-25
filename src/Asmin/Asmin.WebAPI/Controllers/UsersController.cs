using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Asmin.Business.Abstract;
using Asmin.Core.Entities.Concrete;
using Asmin.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asmin.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var userDataResult = await _userManager.GetListAsync();

            if (userDataResult.IsSuccess)
            {
                return Ok(userDataResult.Data);
            }

            return BadRequest(userDataResult.Message);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userDataResult = await _userManager.GetByIdAsync(id);

            if (userDataResult.IsSuccess)
            {
                return Ok(userDataResult.Data);
            }

            return BadRequest(userDataResult.Message);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(User user)
        {
            var checkIfUserAdded = await _userManager.AddAsync(user);

            if (!checkIfUserAdded.IsSuccess)
            {
                BadRequest(checkIfUserAdded.Message);
            }

            return Ok(checkIfUserAdded.Message);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(User user)
        {
            var checkIfUserUpdated = await _userManager.UpdateAsync(user);

            if (!checkIfUserUpdated.IsSuccess)
            {
                return BadRequest(checkIfUserUpdated.Message);
            }

            return Ok(checkIfUserUpdated.Message);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Remove(User user)
        {
            var checkUserIsRemoved = await _userManager.RemoveAsync(user);

            if (!checkUserIsRemoved.IsSuccess)
            {
                return BadRequest(checkUserIsRemoved.Message);
            }

            return Ok(checkUserIsRemoved.Message);
        }
        [HttpGet]
        [Route("test")]
        public void TransactionalTestMethod()
        {
            _userManager.TransactionalTestMethod();
        }
    }
}