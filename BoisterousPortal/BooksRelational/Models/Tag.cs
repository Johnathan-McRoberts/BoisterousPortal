namespace BooksRelational.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BookRead> BooksRead { get; set; }

        public Tag()
        {
            Id = 0;
            Name = string.Empty;
            BooksRead = new HashSet<BookRead>();
        }
    }
}
