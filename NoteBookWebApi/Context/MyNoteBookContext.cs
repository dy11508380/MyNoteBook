using Microsoft.EntityFrameworkCore;

namespace NoteBookWebApi.Context
{
    public class MyNoteBookContext:DbContext
    {
        public DbSet<NoteBook> MyNoteBook { get; set; }

        public DbSet<Memo> Memo { get; set; }

        public DbSet<User> User { get; set; }


        public MyNoteBookContext(DbContextOptions<MyNoteBookContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
