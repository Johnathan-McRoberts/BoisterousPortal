namespace BooksRelational.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }

        public Author()
        {
            Id = 0;
            Name = string.Empty;
            Nationality = string.Empty;
        }
    }
}
