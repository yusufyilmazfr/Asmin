using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Asmin.Core.Configuration.Context;
using Asmin.Core.Entities.Concrete;
using Asmin.Core.Utilities.Result;
using Asmin.Entities.CustomEntities.Request.User;
using Asmin.Entities.CustomEntities.Response.User;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Asmin.WebMVC.Services.Rest.UserService
{
    public class UserApiService : IUserApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAsminConfigurationContext _asminConfigurationContext;

        public UserApiService(IHttpClientFactory httpClientFactory, IAsminConfigurationContext asminConfigurationContext, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _asminConfigurationContext = asminConfigurationContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<DataResult<UserLoginResponse>> LoginAsync(UserLoginRequest loginRequest)
        {
            var httpClient = _httpClientFactory.CreateClient();

            httpClient.BaseAddress = new Uri(_asminConfigurationContext.ApiUrl);

            var httpContent = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");

            var responseMessage = await httpClient.PostAsync("/users/login", httpContent);

            var content = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<DataResult<UserLoginResponse>>(content);
        }

        public async Task<DataResult<List<User>>> GetListAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();

            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("token", out string token);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            httpClient.BaseAddress = new Uri(_asminConfigurationContext.ApiUrl);

            var responseMessage = await httpClient.GetAsync("/users");

            var content = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<DataResult<List<User>>>(content);
        }

        public async Task<DataResult<int>> GetCountAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();

            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("token", out string token);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            httpClient.BaseAddress = new Uri(_asminConfigurationContext.ApiUrl);

            var responseMessage = await httpClient.GetAsync("/users/count");

            var content = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<DataResult<int>>(content);
        }
    }
}
