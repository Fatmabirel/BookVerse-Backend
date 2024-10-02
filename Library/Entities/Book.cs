namespace Library.Entities
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public int author_id { get; set; }
        public int publication_year { get; set; }
        public int stock { get; set; }
        public int category_id { get; set; }
        public string image_url { get; set; }
        public virtual Author Author { get; set; } // Author ile ilişki
        public virtual Category Category { get; set; } // Category ile ilişki
    }
}
