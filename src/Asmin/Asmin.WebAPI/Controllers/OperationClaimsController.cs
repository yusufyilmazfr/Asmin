using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asmin.Business.Abstract;
using Asmin.Packages.JWT.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asmin.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {
        private readonly IOperationClaimManager _operationClaimManager;

        public OperationClaimsController(IOperationClaimManager operationClaimManager)
        {
            _operationClaimManager = operationClaimManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var operationClaimsResult = await _operationClaimManager.GetClaimsAsync();

            if (!operationClaimsResult.IsSuccess)
            {
                return BadRequest(operationClaimsResult);
            }

            return Ok(operationClaimsResult);
        }
    }
}
