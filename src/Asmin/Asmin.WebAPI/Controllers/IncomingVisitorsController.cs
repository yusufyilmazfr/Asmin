using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asmin.Business.Abstract;
using Asmin.Entities.Concrete;
using Asmin.Packages.JWT.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asmin.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [TypeFilter(typeof(AsminTokenAuthFilter))]
    public class IncomingVisitorsController : ControllerBase
    {
        private readonly IIncomingVisitorManager _incomingVisitorManager;

        public IncomingVisitorsController(IIncomingVisitorManager incomingVisitorManager)
        {
            _incomingVisitorManager = incomingVisitorManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(IncomingVisitor incomingVisitor)
        {
            var checkIncomingVisitorResult = await _incomingVisitorManager.AddAsync(incomingVisitor);

            if (!checkIncomingVisitorResult.IsSuccess)
            {
                return BadRequest(checkIncomingVisitorResult);
            }

            return Ok(checkIncomingVisitorResult);
        }

        [HttpGet]
        [Route("count")]
        public async Task<IActionResult> GetCount()
        {
            var checkIncomingVisitorsCount = await _incomingVisitorManager.GetCountAsync();

            if (!checkIncomingVisitorsCount.IsSuccess)
            {
                return BadRequest(checkIncomingVisitorsCount);
            }

            return Ok(checkIncomingVisitorsCount);
        }
    }
}
