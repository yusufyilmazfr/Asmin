using System.Collections.Generic;
using System.Threading.Tasks;
using Asmin.Core.Entities.Concrete;
using Asmin.Core.Utilities.Result;
using Asmin.Entities.CustomEntities.Request.User;
using Asmin.Entities.CustomEntities.Response.User;

namespace Asmin.WebMVC.Services.Rest.UserService
{
    public interface IUserApiService
    {
        Task<DataResult<UserLoginResponse>> LoginAsync(UserLoginRequest loginRequest);
        Task<DataResult<List<User>>> GetListAsync();
        Task<DataResult<int>> GetCountAsync();
    }
}
