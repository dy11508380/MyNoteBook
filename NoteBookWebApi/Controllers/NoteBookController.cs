using Microsoft.AspNetCore.Mvc;
using NoteBookWebApi.Context;
using MyNoteBook.Share.Dtos;
using MyNoteBook.Share.Parameters;
using NoteBookWebApi.Context;
using NoteBookWebApi.Context.UnitOfWork;
using NoteBookWebApi.Service;

namespace NoteBookWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class NoteBookController : ControllerBase
    {

        public readonly NoteBookService ntService;

        public NoteBookController(NoteBookService ntService)
        {
            this.ntService = ntService;
        }


        [HttpGet]
        public async Task<ApiResponse> Get(int id) => await ntService.GetSingleAsync(id);

        [HttpGet]
        public async Task<ApiResponse> GetAll([FromQuery] NoteBookParameter parameter) => await ntService.GetAllAsync(parameter);

        [HttpGet]
        public async Task<ApiResponse> Summary() => await ntService.Summary();


        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] NoteBookDto model) => await ntService.AddAsync(model);

        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] NoteBookDto model) => await ntService.UpdateAsync(model);

        [HttpDelete]
        public async Task<ApiResponse> Delete(int id) => await ntService.DeleteAsync(id);

    }
}
