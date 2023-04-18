using Microsoft.AspNetCore.Mvc;
using NoteBookWebApi.Context;
using MyNoteBook.Share.Dtos;
using MyNoteBook.Share.Parameters;
using NoteBookWebApi.Service;

namespace NoteBookWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : ControllerBase
    {

        public readonly LoginService service;

        public LoginController(LoginService ntService)
        {
            this.service = ntService;
        }


        [HttpPost]
        public async Task<ApiResponse> Login([FromBody] UserDto model) => await service.LoginAsync(model.Account, model.Password);


        [HttpPost]
        public async Task<ApiResponse> Register([FromBody] UserDto model) => await service.Register(model);



    }
}
