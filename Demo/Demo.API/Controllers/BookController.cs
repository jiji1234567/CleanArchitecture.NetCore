using Demo.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public IAuthorRepository AuthorRepository { get; }
        public IBookRepository BookRepository { get; }

        public BookController(IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            AuthorRepository = authorRepository;
            BookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooksAsync([FromQuery]int authorId)
        {
            if (!await AuthorRepository.IsExistAsync(authorId))
            {
                return NotFound();
            }

            return Ok(BookRepository.GetBooksAsync(authorId));
        }

        [HttpGet("{bookId}")]
        public async Task<ActionResult<Book>> GetBookAsync(int authorId, int bookId)
        {
            if (! await AuthorRepository.IsExistAsync(authorId))
            {
                return NotFound();
            }

            var targetBook = await BookRepository.GetBookAsync(authorId, bookId);
            if (targetBook == null)
            {
                return NotFound();
            }

            return targetBook;
        }
    }
    

}
