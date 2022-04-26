using Demo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IAuthorRepository : IRepositoryBase<Author>, IRepositoryBase2<Author, int>
    {
    }
}
