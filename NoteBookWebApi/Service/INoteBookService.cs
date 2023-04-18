using MyNoteBook.Share.Dtos;
using MyNoteBook.Share.Parameters;
using NoteBookWebApi.Context;

namespace NoteBookWebApi.Service
{
    public interface INoteBookService: IBaseService<NoteBookDto>
    {
        Task<ApiResponse> GetAllAsync(NoteBookParameter parameter);
    }
}
