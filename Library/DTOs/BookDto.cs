namespace Library.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public int PublicationYear { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
    }
}
