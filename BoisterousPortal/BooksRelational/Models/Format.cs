namespace BooksRelational.Models
{
    public class Format
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Format()
        {
            Id = 0;
            Name = string.Empty;
        }
    }
}
