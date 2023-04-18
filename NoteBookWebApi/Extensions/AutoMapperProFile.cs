using AutoMapper;
using MyNoteBook.Share.Dtos;
using NoteBookWebApi.Context;

namespace NoteBookWebApi.Extensions
{
    public class AutoMapperProFile:MapperConfigurationExpression
    {
        public AutoMapperProFile()
        {
            CreateMap<NoteBook, NoteBookDto>().ReverseMap();
            CreateMap<Memo, MemoDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
