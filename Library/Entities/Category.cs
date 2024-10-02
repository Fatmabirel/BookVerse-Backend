using System.Text.Json.Serialization;

namespace Library.Entities
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
