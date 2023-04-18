using Microsoft.EntityFrameworkCore;
using NoteBookWebApi.Context.UnitOfWork;
using NoteBookWebApi.Migrations;
using System.Reflection.Metadata;

namespace NoteBookWebApi.Context.Repository
{

    public class MyNoteBookRepository : Repository<NoteBook>, IRepository<NoteBook>
    {
        public MyNoteBookRepository(MyNoteBookContext dbContext) : base(dbContext)
        {
        }
    }
}
