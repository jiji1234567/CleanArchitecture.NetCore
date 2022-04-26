using Demo.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public IAuthorRepository AuthorRepository { get; }

        public AuthorController(IAuthorRepository authorRepository)
        {
            AuthorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            var authors = await AuthorRepository.GetAllAsync();
            return Ok(authors);
        }

        [HttpGet("{authorId}")]
        public async Task<ActionResult<Author>> GetAuthor(int authorId)
        {
            var author =await AuthorRepository.GetByIdAsync(authorId);

            if (author == null)
            {
                return NotFound();
            }
            else
            {
                return author;
            }
        }

    }





}
