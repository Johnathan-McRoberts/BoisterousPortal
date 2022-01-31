namespace PortalRepositories
{
    public interface IBooksDbRepository
    {
        void AddNewElements(IEnumerable<BooksDbReader.Books.Book> sourceBooks);
    }
}
