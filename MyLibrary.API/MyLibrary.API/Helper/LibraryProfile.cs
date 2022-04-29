using AutoMapper;
using MyLibrary.API.Models;

namespace MyLibrary.API.Helper
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            CreateMap<BookForUpdateDto, BookDto>();
        }
        
    }
}
