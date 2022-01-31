namespace PortalRepositories.Dtos
{
    public class BookReadDetailDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime DateRead { get; set; }

        public int Pages { get; set; }

        public string Note { get; set; }

        public string ImageUrl { get; set; }

        public string User { get; set; }

        public string Nationality { get; set; }

        public string Format { get; set; }

        public string Language { get; set; }

        public List<string> Tags { get; set; }

        public BookReadDetailDto()
        {
            Id = 0;
            DateRead = DateTime.MinValue;
            Title = string.Empty;
            Pages = 0;
            Note = string.Empty;
            ImageUrl = string.Empty;
            User = string.Empty;

            Author = string.Empty;
            Nationality = string.Empty;
            Format = string.Empty;
            Language = string.Empty;
            Tags = new List<string>();
        }

    }
}
