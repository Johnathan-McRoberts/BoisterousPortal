namespace BooksRelational.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Language()
        {
            Id = 0;
            Name = string.Empty;
        }
    }
}
