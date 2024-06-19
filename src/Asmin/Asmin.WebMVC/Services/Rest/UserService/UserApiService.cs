using System.Collections.Generic;
using System.Threading.Tasks;
using Asmin.Core.Entities.Concrete;
using Asmin.Core.Utilities.Result;
using Asmin.Entities.CustomEntities.Request.User;
using Asmin.Entities.CustomEntities.Response.User;
using Asmin.WebMVC.Services.Rest.Base;

namespace Asmin.WebMVC.Services.Rest.UserService
{
    public class UserApiService : IUserApiService
    {
        private readonly IHttpService _httpService;

        public UserApiService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public Task<DataResult<UserLoginResponse>> LoginAsync(UserLoginRequest loginRequest)
        {
            return _httpService.PostAsync<DataResult<UserLoginResponse>>("/users/login", loginRequest);
        }

        public Task<DataResult<List<User>>> GetListAsync()
        {
            return _httpService.GetAsync<DataResult<List<User>>>("/users");
        }

        public Task<DataResult<int>> GetCountAsync()
        {
            return _httpService.GetAsync<DataResult<int>>("/users/count");
        }
    }
}
