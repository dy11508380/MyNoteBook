using MyNoteBook.Share.Dtos;
using NoteBookWebApi.Context;

namespace NoteBookWebApi.Service
{
    public interface ILoginService
    {
        Task<ApiResponse> LoginAsync(string account,string Password);

        Task<ApiResponse> Register(UserDto user);
    }
}
