namespace BooksRelational.Models
{
    public class BookRead
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public string Note { get; set; }
        public string ImageUrl { get; set; }
        public string User { get; set; }
        
        public Author Author { get; set; }
        public Format Format { get; set; }
        public Language OriginalLanguage { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public BookRead()
        {
            Id = 0;
            Date = DateTime.Now;
            Title = string.Empty;
            Pages = 0;
            Note = string.Empty;
            ImageUrl = string.Empty;
            User = string.Empty;

            Author = new Author();
            Format = new Format();
            OriginalLanguage = new Language();
            Tags = new HashSet<Tag>();
        }
    }
}
