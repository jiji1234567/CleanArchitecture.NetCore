using System.ComponentModel.DataAnnotations;

namespace MyLibrary.API.Models
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }

    public class AuthorForCreationDto
    {
        [Required(ErrorMessage = "you must geben name")]
        [MaxLength(20, ErrorMessage = "max 20")]
        public string Name { get; set; }

        public int Age { get; set; }

        [EmailAddress(ErrorMessage = "email format not correct")]
        public string Email { get; set; }
    }
}
