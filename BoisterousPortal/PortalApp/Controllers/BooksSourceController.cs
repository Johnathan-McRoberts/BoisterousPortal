namespace PortalApp.Controllers
{
    using BooksDbReader.Books;
    using BooksDbReader.Settings;
    using BooksDbReader.Utilities;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;

    [ApiController]
    [EnableCors]
    [Route("[controller]")]
    public class BooksSourceController
    {
        /// <summary>
        /// The books data controller utilities.
        /// </summary>
        private readonly BooksDataUtilities _booksDataControllerUtilities;

        [HttpGet("[action]")]
        public IEnumerable<Book> GetAllBooks()
        {
            return _booksDataControllerUtilities.GetAllBooks();
        }

        public BooksSourceController(IOptions<MongoDbSettings> config)
        {
            MongoDbSettings dbSettings = config.Value;

            _booksDataControllerUtilities =
                new BooksDataUtilities(dbSettings);
        }
    }
}
