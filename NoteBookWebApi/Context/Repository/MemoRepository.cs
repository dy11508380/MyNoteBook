using Microsoft.EntityFrameworkCore;
using NoteBookWebApi.Context.UnitOfWork;

namespace NoteBookWebApi.Context.Repository
{
    public class MemoRepository : Repository<Memo>, IRepository<Memo>
    {
        public MemoRepository(MyNoteBookContext dbContext) : base(dbContext)
        {
        }
    }
}
