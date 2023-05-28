namespace MvcLibraryApp.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Author { get; set; }
    }
}
