namespace MyLibrary.API.Models
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public Guid AuthorId { get; set; }
    }

    public class BookForCreationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
    }

    public class BookForUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
    }
}
