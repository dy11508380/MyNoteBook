using Microsoft.AspNetCore.Mvc;
using NoteBookWebApi.Context;
using MyNoteBook.Share.Dtos;
using MyNoteBook.Share.Parameters;
using NoteBookWebApi.Service;

namespace NoteBookWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MemoController : ControllerBase
    {

        public readonly MemoService ntService;

        public MemoController(MemoService ntService)
        {
            this.ntService = ntService;
        }


        [HttpGet]
        public async Task<ApiResponse> Get(int id) => await ntService.GetSingleAsync(id);

        [HttpGet]
        public async Task<ApiResponse> GetAll([FromQuery] QueryParameter parameter) => await ntService.GetAllAsync(parameter);


        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] MemoDto model) => await ntService.AddAsync(model);

        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] MemoDto model) => await ntService.UpdateAsync(model);

        [HttpDelete]
        public async Task<ApiResponse> Delete(int id) => await ntService.DeleteAsync(id);

    }
}
