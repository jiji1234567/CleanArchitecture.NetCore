using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entity
{
    public class Author
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public DateTimeOffset BirthData { get; set; }

        [Required]
        [MaxLength(40)]
        public string BirthPlace { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
