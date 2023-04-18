using MyNoteBook.Common.Models;
using MyNoteBook.Share;
using MyNoteBook.Share.Dtos;
using MyNoteBook.Share.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteBook.Service
{
    public interface INoteBookService:IBaseService<NoteBookDto>
    {
        Task<ApiResponse<PagedList<NoteBookDto>>> GetAllAsync(NoteBookParameter parameter);

        Task<ApiResponse<SummaryDto>> SummaryAsync();
    }
}
