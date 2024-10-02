using System.Text.Json.Serialization;

namespace Library.Entities
{
    public class Author
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image_url { get; set; }
        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    }
}
