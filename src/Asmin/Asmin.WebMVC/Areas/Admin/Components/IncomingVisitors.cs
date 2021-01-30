using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Asmin.WebMVC.Services.Rest.IncomingVisitorService;

namespace Asmin.WebMVC.Areas.Admin.Components
{
    public class IncomingVisitors : ViewComponent
    {
        private readonly IIncomingVisitorApiService _incomingVisitorApiService;

        public IncomingVisitors(IIncomingVisitorApiService incomingVisitorApiService)
        {
            _incomingVisitorApiService = incomingVisitorApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var visitorsCountResult = await _incomingVisitorApiService.GetCountAsync();

            return View(visitorsCountResult.Data);
        }
    }
}
