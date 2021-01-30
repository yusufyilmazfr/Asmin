using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Asmin.Core.Configuration.Context;
using Asmin.Core.Entities.Concrete;
using Asmin.Core.Utilities.Result;
using Asmin.Entities.Concrete;
using Asmin.Entities.CustomEntities.Response.User;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Asmin.WebMVC.Services.Rest.IncomingVisitorService
{
    public class IncomingVisitorApiService : IIncomingVisitorApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAsminConfigurationContext _asminConfigurationContext;

        public IncomingVisitorApiService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IAsminConfigurationContext asminConfigurationContext)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _asminConfigurationContext = asminConfigurationContext;
        }


        public async Task<Result> AddAsync(IncomingVisitor incomingVisitor)
        {
            var httpClient = _httpClientFactory.CreateClient();

            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("token", out string token);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            httpClient.BaseAddress = new Uri(_asminConfigurationContext.ApiUrl);

            var httpContent = new StringContent(JsonConvert.SerializeObject(incomingVisitor), Encoding.UTF8, "application/json");

            var responseMessage = await httpClient.PostAsync("/incomingvisitors", httpContent);

            var content = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Result>(content);
        }

        public async Task<DataResult<int>> GetCountAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();

            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("token", out string token);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            httpClient.BaseAddress = new Uri(_asminConfigurationContext.ApiUrl);

            var responseMessage = await httpClient.GetAsync("/incomingvisitors/count");

            var content = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<DataResult<int>>(content);
        }
    }
}
