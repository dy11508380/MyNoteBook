using NoteBookWebApi.Context.UnitOfWork;

namespace NoteBookWebApi.Context.Repository
{
    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(MyNoteBookContext dbContext) : base(dbContext)
        {
        }
    }
}
