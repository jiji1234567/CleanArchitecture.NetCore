using Demo.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class LibrayDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
        }

    }
}