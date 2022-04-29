using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.API.Models;
using MyLibrary.API.Services;

namespace MyLibrary.API.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public IAuthorRepository AuthorRepository { get; }

        public AuthorController(IAuthorRepository authorRepository)
        {
            AuthorRepository = authorRepository;
        }

        [HttpGet]
        public ActionResult<List<AuthorDto>> GetAuthors()
        {
            return Ok(AuthorRepository.GetAuthors().ToList());
        }

        [HttpGet("{authorId}", Name = nameof(GetAuthor))]
        public ActionResult<AuthorDto> GetAuthor(Guid authorId)
        {
            var author = AuthorRepository.GetAuthor(authorId);

            if (author == null)
            {
                return NotFound();
            }
            else
            {
                return author;
            }
        }

        [HttpPost]
        public IActionResult CreateAuthor(AuthorForCreationDto authorForCreationDto)
        {
            var authorDto = new AuthorDto
            {
                Name = authorForCreationDto.Name,
                Age = authorForCreationDto.Age,
                Email = authorForCreationDto.Email
            };

            AuthorRepository.AddAuthor(authorDto);

            // 返回201 Created 状态码，并在响应消息头中包含 Location 项，它的值是新创建资源的 URL
            // 第一个参数是要调用 Action 的路由名称
            // 第二个参数是包含要调用 Action 所需要参数的匿名对象
            // 最后一个参数是代表添加成功后的资源本身
            return CreatedAtRoute(nameof(GetAuthor), new { authorId = authorDto.Id }, authorDto);
        }
    }
}
