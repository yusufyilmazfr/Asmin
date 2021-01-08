using Asmin.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asmin.WebMVC.Areas.Admin.Components
{
    public class IncomingVisitors : ViewComponent
    {
        private readonly IIncomingVisitorManager _incomingVisitorManager;

        public IncomingVisitors(IIncomingVisitorManager incomingVisitorManager)
        {
            _incomingVisitorManager = incomingVisitorManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var visitorsCountResult = await _incomingVisitorManager.GetCountAsync();

            return View(visitorsCountResult.Data);
        }
    }
}
