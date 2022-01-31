namespace PortalRepositories.Dtos
{
    public class BooksReadSummaryDto
    {
        public List<BookReadSummary> SummarySet { get; set; }

        public BooksReadSummaryDto()
        {
            SummarySet = new List<BookReadSummary>();
        }
    }

}
