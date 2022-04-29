using AutoMapper;
using MyLibrary.API.Data;
using MyLibrary.API.Models;

namespace MyLibrary.API.Services.MockRepository
{
    public class BookMockRepository : IBookRepository
    {
        public readonly IMapper _mapper;
        public BookMockRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public void AddBook(BookDto book)
        {
            LibraryMockData.Current.Books.Add(book);
        }

        public void DeleteBook(BookDto book)
        {
            LibraryMockData.Current.Books.Remove(book);
        }

        public BookDto GetBookForAuthor(Guid authorId, Guid bookId)
        {
            return LibraryMockData.Current.Books.FirstOrDefault(b => b.AuthorId == authorId && b.Id == bookId);
        }

        public IEnumerable<BookDto> GetBooksForAuthor(Guid authorId)
        {
            return LibraryMockData.Current.Books.Where(b => b.AuthorId == authorId).ToList();
        }

        public void UpdateBook(Guid authorId, Guid bookId, BookForUpdateDto book)
        {
            var originalBook = GetBookForAuthor(authorId, bookId);

            _mapper.Map(book, originalBook);
        }
    }
}
