using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Asmin.Core.Configuration.Context;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Asmin.WebMVC.Services.Rest.Base
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAsminConfigurationContext _asminConfigurationContext;

        public HttpService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IAsminConfigurationContext asminConfigurationContext)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _asminConfigurationContext = asminConfigurationContext;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var httpClient = _httpClientFactory.CreateClient();

            AddAuthorizationTokenWhenExists(httpClient);

            httpClient.BaseAddress = new Uri(_asminConfigurationContext.ApiUrl);

            var responseMessage = await httpClient.GetAsync(url);

            var content = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<T> PostAsync<T>(string url, object data)
        {
            var httpClient = _httpClientFactory.CreateClient();

            AddAuthorizationTokenWhenExists(httpClient);

            httpClient.BaseAddress = new Uri(_asminConfigurationContext.ApiUrl);

            var httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            var responseMessage = await httpClient.PostAsync(url, httpContent);

            var content = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);
        }

        private void AddAuthorizationTokenWhenExists(HttpClient httpClient)
        {
            var checkTokenExists = _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("token", out string token);

            if (checkTokenExists)
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
