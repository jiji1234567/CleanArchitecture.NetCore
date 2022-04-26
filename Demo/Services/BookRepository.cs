using Demo.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookRepository : RepositoryBase<Book, int>, IBookRepository
    {
        public BookRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> GetBookAsync(int authorId, int bookId)
        {
            return await _dbContext.Set<Book>().SingleOrDefaultAsync(b => b.AuthorId == authorId && b.Id == bookId);
        }

        public Task<IEnumerable<Book>> GetBooksAsync(int authorId)
        {
            return Task.FromResult(_dbContext.Set<Book>().Where(b => b.AuthorId == authorId).AsEnumerable());
        }

        public async Task<bool> IsExistAsync(int authorId, int bookId)
        {
            return await _dbContext.Set<Book>().AnyAsync(book => book.AuthorId == authorId && book.Id == bookId);
        }
    }
}
