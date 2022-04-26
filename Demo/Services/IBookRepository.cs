using Demo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBookRepository : IRepositoryBase<Book>, IRepositoryBase2<Book, int>
    {

        Task<IEnumerable<Book>> GetBooksAsync(int authorId);
        Task<Book> GetBookAsync(int authorId, int bookId);

        Task<bool> IsExistAsync(int authorId, int bookId);
    }
}
