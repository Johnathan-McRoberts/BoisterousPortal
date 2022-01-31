using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using PortalRepositories;
using PortalRepositories.Dtos;

using BooksDbReader.Books;
using BooksDbReader.Settings;
using BooksDbReader.Utilities;
using BooksRelational.Data;

namespace PortalApp.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("[controller]")]
    public class BooksDbController
    {
        /// <summary>
        /// The books data controller utilities.
        /// </summary>
        private readonly BooksDataUtilities _booksDataControllerUtilities;

        [HttpGet]
        [Route("book/{bookId}")]
        public BookReadDetailDto GetBookReadDetailDtos(int bookId)
        {
            BookReadDetailDto detail = new BookReadDetailDto();
            BooksRelationalContextFactory contextFactory =
                    new BooksRelationalContextFactory();

            using (BooksRelationalContext db =
                contextFactory.CreateDbContext(new string[] { }))
            {
                BooksDbRepository booksDbRepository =
                    new BooksDbRepository(db);
                detail =
                     booksDbRepository.GetBookReadDetail(bookId);
            }

            return detail;
        }

        [HttpGet("book-summaries")]
        public BooksReadSummaryDto GetBookReadSummaryDtos()
        {
            List<BookReadSummary> summaries = new List<BookReadSummary>();

            BooksRelationalContextFactory contextFactory =
                    new BooksRelationalContextFactory();

            using (BooksRelationalContext db =
                contextFactory.CreateDbContext(new string[] { }))
            {

                BooksDbRepository booksDbRepository =
                    new BooksDbRepository(db);
                summaries =
                     booksDbRepository.GetBookReadSummaryDtos();
            }

            return new BooksReadSummaryDto { SummarySet = summaries };
        }

        [HttpGet("[action]")]
        public int GetDbBooksCount()
        {
            int count = 0;
            BooksRelationalContextFactory contextFactory =
                new BooksRelationalContextFactory();

            using (BooksRelationalContext db =
                contextFactory.CreateDbContext(new string[] { }))
            {
                count = db.BooksRead.Count();
            }

            return count;
        }

        [HttpGet("[action]")]
        public int GetSourceBooksCount()
        {
            IEnumerable<Book>? allBooks =
                _booksDataControllerUtilities.GetAllBooks();
            return allBooks.Count();
        }

        [HttpGet("[action]")]
        public int GetSyncBooksCount()
        {
            List<Book> sourceBooks =
                _booksDataControllerUtilities.GetAllBooks().ToList();
            int sourceBooksCount = sourceBooks.Count();

            int dbBooksCount = 0;

            BooksRelationalContextFactory contextFactory =
                new BooksRelationalContextFactory();

            using (BooksRelationalContext db =
                contextFactory.CreateDbContext(new string[] { }))
            {
                dbBooksCount = db.BooksRead.Count();

                if (sourceBooksCount != dbBooksCount)
                {
                    BooksDbRepository booksDbRepository =
                        new BooksDbRepository(db);

                    booksDbRepository.AddNewElements(sourceBooks);
                }
            }

            return sourceBooksCount - dbBooksCount;
        }

        public BooksDbController(IOptions<MongoDbSettings> config)
        {
            // Setup the source connection
            MongoDbSettings dbSettings = config.Value;

            _booksDataControllerUtilities =
                new BooksDataUtilities(dbSettings);
        }
    }
}
