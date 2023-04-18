using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteBookWebApi.Context
{
    public class NoteBook: BaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int Status { get; set; }
    }

    public class NoteBookEntityConfig : IEntityTypeConfiguration<NoteBook>
    {
        public void Configure(EntityTypeBuilder<NoteBook> builder)
        {
            builder.ToTable("MyNoteBook");
        }
    }
}
