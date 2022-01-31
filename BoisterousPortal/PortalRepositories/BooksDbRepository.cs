using BooksDbReader.Books;

using BooksRelational.Data;
using BooksRelational.Models;

using PortalRepositories.Dtos;

namespace PortalRepositories
{
    public class BooksDbRepository : IBooksDbRepository
    {
        private readonly BooksRelationalContext _dbContext;

        private int UpdateFormats(List<Book> sourceBooks)
        {
            // Get the unique formats from the source
            Dictionary<string, Format> formatsMap =
                new Dictionary<string, Format>();

            foreach (Book book in sourceBooks)
            {
                // see if already have the format
                if (!formatsMap.ContainsKey(book.Format))
                {
                    formatsMap.Add(
                        book.Format,
                        new Format() { Name = book.Format, });
                }
            }

            // Get them as a list
            List<Format> formats = new List<Format>();
            foreach (Format format in formatsMap.Values.OrderBy(x => x.Name))
            {
                formats.Add(format);
            }

            // Loop through adding the missing formats to the db
            int added = 0;
            foreach (Format format in formats)
            {
                if (!_dbContext.Formats.Any(x => x.Name == format.Name))
                {
                    _dbContext.Formats.Add(format);
                    added++;
                }
            }

            if (added > 0)
            {
                _dbContext.SaveChanges();
            }

            return added;
        }

        private int UpdateLanguages(List<Book> sourceBooks)
        {
            // Get the unique languages from the source
            Dictionary<string, Language> languagesMap =
                new Dictionary<string, Language>();

            foreach (Book book in sourceBooks)
            {
                // see if already have the language
                if (!languagesMap.ContainsKey(book.OriginalLanguage))
                {
                    languagesMap.Add(
                        book.OriginalLanguage,
                        new Language() { Name = book.OriginalLanguage, });
                }

            }

            // Get them as a list
            List<Language> languages = new List<Language>();
            foreach (Language language in languagesMap.Values.OrderBy(x => x.Name))
            {
                languages.Add(language);
            }

            // Loop through adding the missing languages to the db
            int added = 0;
            foreach (Language language in languages)
            {
                if (!_dbContext.Languages.Any(x => x.Name == language.Name))
                {
                    _dbContext.Languages.Add(language);
                    added++;
                }
            }

            if (added > 0)
            {
                _dbContext.SaveChanges();
            }

            return added;
        }

        private int UpdateAuthors(List<Book> sourceBooks)
        {
            // Get the unique formats from the source
            Dictionary<string, Author> authorsMap =
                new Dictionary<string, Author>();

            foreach (Book book in sourceBooks)
            {
                // see if already have the author
                if (!authorsMap.ContainsKey(book.Author))
                {
                    authorsMap.Add(
                        book.Author,
                        new Author() { Name = book.Author, Nationality = book.Nationality });
                }
            }

            // Get them as a list
            List<Author> authors = new List<Author>();
            foreach (Author author in authorsMap.Values.OrderBy(x => x.Name))
            {
                authors.Add(author);
            }

            // Loop through adding the missing authors to the db
            int added = 0;
            foreach (Author author in authors)
            {
                if (!_dbContext.Authors.Any(x => x.Name == author.Name))
                {
                    _dbContext.Authors.Add(author);
                    added++;
                }
            }

            if (added > 0)
            {
                _dbContext.SaveChanges();
            }

            return added;
        }

        private int UpdateTags(List<Book> sourceBooks)
        {
            // Get the unique formats from the source
            Dictionary<string, Tag> tagsMap =
                new Dictionary<string, Tag>();

            foreach (Book book in sourceBooks)
            {
                string[] tagsList = book.Tags;

                foreach (string tag in tagsList)
                {
                    // see if already have the format
                    if (!tagsMap.ContainsKey(tag))
                    {
                        tagsMap.Add(
                            tag,
                            new Tag() { Name = tag });
                    }
                }
            }

            // Get them as a list
            List<Tag> tags = new List<Tag>();
            foreach (Tag tag in tagsMap.Values.OrderBy(x => x.Name))
            {
                tags.Add(tag);
            }

            // Loop through adding the missing tags to the db
            int added = 0;
            foreach (Tag tag in tags)
            {
                if (!_dbContext.Tags.Any(x => x.Name == tag.Name))
                {
                    _dbContext.Tags.Add(tag);
                    added++;
                }
            }

            if (added > 0)
            {
                _dbContext.SaveChanges();
            }

            return added;
        }

        public void AddNewElements(IEnumerable<Book> sourceBooks)
        {
            List<Book> source = new List<Book>(sourceBooks);

            // Update the elements the book uses
            UpdateFormats(source);
            UpdateLanguages(source);
            UpdateAuthors(source);
            UpdateTags(source);

            // Get the book elements not already in the table
            List<Book> booksToAdd = new List<Book>();
            foreach (Book book in sourceBooks)
            {
                if (!_dbContext.BooksRead.Any(x => x.Title == book.Title && x.Date == book.Date))
                {
                    booksToAdd.Add(book);
                }
            }

            List<BooksRelational.Models.BookRead> booksReadToAdd =
                new List<BooksRelational.Models.BookRead>();
            foreach (Book book in booksToAdd.OrderBy(x => x.Date))
            {
                // Make up the book read ready for the database
                BooksRelational.Models.BookRead bookRead =
                    new BooksRelational.Models.BookRead()
                    {
                        Title = book.Title,
                        ImageUrl = book.ImageUrl,
                        Date = book.Date,
                        Note = book.Note == null ? string.Empty : book.Note,
                        Pages = book.Pages
                    };
                bookRead.Author = _dbContext.Authors.First(x => x.Name == book.Author);
                bookRead.Format = _dbContext.Formats.First(x => x.Name == book.Format);
                bookRead.OriginalLanguage = _dbContext.Languages.First(x => x.Name == book.OriginalLanguage);
                foreach (string tag in book.Tags)
                {
                    bookRead.Tags.Add(
                        _dbContext.Tags.First(x => x.Name == tag));
                }

                booksReadToAdd.Add(bookRead);
            };

            // Loop through adding the missing books to the db
            int added = 0;
            foreach (BooksRelational.Models.BookRead bookRead in booksReadToAdd)
            {
                _dbContext.BooksRead.Add(bookRead);
                added++;
            }

            if (added > 0)
            {
                _dbContext.SaveChanges();
            }
        }

        public List<BookReadSummary> GetBookReadSummaryDtos()
        {
            // Set up the summary query.
            IQueryable<BookReadSummary> summariesQuery =
                from book in _dbContext.BooksRead
                select new BookReadSummary
                {
                    Author = book.Author.Name,
                    Title = book.Title,
                    Pages = book.Pages,
                    DateRead = book.Date,
                    Id = book.Id
                };

            // Run the query and convert the results into a list.
            List<BookReadSummary> summariesData =
                summariesQuery.ToList();

            return summariesData;
        }

        public BookReadDetailDto GetBookReadDetail(int bookId)
        {
            // Set up the summary query.
            IQueryable<BookReadDetailDto> summariesQuery =
                from book in _dbContext.BooksRead
                where book.Id == bookId
                select new BookReadDetailDto
                {
                    Id = book.Id,

                    Title = book.Title,
                    Pages = book.Pages,
                    DateRead = book.Date,
                    Note = book.Note,
                    ImageUrl = book.ImageUrl,
                    User = book.User,

                    Author = book.Author.Name,
                    Nationality = book.Author.Nationality,
                    Format = book.Format.Name,
                    Language = book.OriginalLanguage.Name,
                    Tags = book.Tags.Select(x => x.Name).ToList(),
                };

            // Run the query and convert the results into a list.
            List<BookReadDetailDto> summariesData =
                summariesQuery.ToList();

            if (summariesData.Count > 0)
            {
                return summariesData.First();
            }

            return new BookReadDetailDto();
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="BooksDbRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context for the relational books repository.</param>
        public BooksDbRepository(BooksRelationalContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
