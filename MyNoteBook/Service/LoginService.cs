using MyNoteBook.Share;
using MyNoteBook.Share.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteBook.Service
{
    public class LoginService : ILoginService
    {
        protected readonly HttpRestClient restClient;
        private readonly string serviceName= "Login";

        public LoginService(HttpRestClient restClient)
        {
            this.restClient = restClient;
        }

        public async Task<ApiResponse<UserDto>> LoginAsync(UserDto user)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Post;
            request.Route = $"api/{serviceName}/Login";
            request.Parameter = user;
            return await restClient.ExecuteAsync<UserDto>(request);
        }

        public async Task<ApiResponse> RegisterAsync(UserDto user)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Post;
            request.Route = $"api/{serviceName}/Register";
            request.Parameter = user;
            return await restClient.ExecuteAsync(request);
        }
    }
}
