using MyNoteBook.Common.Models;
using MyNoteBook.Share;
using MyNoteBook.Share.Dtos;
using MyNoteBook.Share.Parameters;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteBook.Service
{
    public class NoteBookService: BaseService<NoteBookDto>, INoteBookService
    {
        public NoteBookService(HttpRestClient restClient):base(restClient, "NoteBook")
        {
            
        }

        public async Task<ApiResponse<PagedList<NoteBookDto>>> GetAllAsync(NoteBookParameter parameter)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Get;
            request.Route = $"api/NoteBook/GetAll?pageIndex={parameter.PageIndex}&pageSize={parameter.PageSize}&search={parameter.Search}&status={parameter.Status}";
            return await restClient.ExecuteAsync<PagedList<NoteBookDto>>(request);
        }

        public async Task<ApiResponse<SummaryDto>> SummaryAsync()
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Get;
            request.Route = $"api/NoteBook/Summary";
            return await restClient.ExecuteAsync<SummaryDto>(request);
        }
    }
}
