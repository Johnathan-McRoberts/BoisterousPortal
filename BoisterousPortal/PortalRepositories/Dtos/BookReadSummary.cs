namespace PortalRepositories.Dtos
{
    public class BookReadSummary
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime DateRead { get; set; }

        public int Pages { get; set; }

        public BookReadSummary()
        {
            Id = 0;
            Title = string.Empty;
            Author = string.Empty;
            DateRead = DateTime.MinValue;
            Pages = 0;
        }
    }
}
