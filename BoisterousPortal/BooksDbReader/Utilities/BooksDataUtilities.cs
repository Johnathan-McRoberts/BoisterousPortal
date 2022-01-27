using BooksDbReader.Books;
using BooksDbReader.Databases;
using BooksDbReader.Providers;
using BooksDbReader.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDbReader.Utilities
{
    public class BooksDataUtilities : BaseControllerUtilities
    {
        #region Constants

        public const string DefaultDatabaseConnectionString = "mongodb://localhost:27017";

        /// <summary>
        /// The connection string for the database.
        /// </summary>
        public readonly string DatabaseConnectionString;

        /// <summary>
        /// The export directory to put temporary files into.
        /// </summary>
        public readonly string ExportDirectory;

        public readonly DateTime EarliestDate = DateTime.Now.AddYears(-20);

        public readonly string[] SuffixedDaysOfMonths =
        {
            "0th",  "1st",  "2nd",  "3rd",  "4th",  "5th",  "6th",  "7th",  "8th",  "9th",
            "10th", "11th", "12th", "13th", "14th", "15th", "16th", "17th", "18th", "19th",
            "20th", "21st", "22nd", "23rd", "24th", "25th", "26th", "27th", "28th", "29th",
            "30th", "31st"
        };

        private readonly string AuthCodeText = "AUTH-CODE";

        private readonly string ActivateTimeText = "ACTIVATE-TIME";

        private readonly string AuthMessageSubject = "McBob's Books Authentication";

        private readonly string AuthMessageBodyTop =
            @"<body>
                <p>Please enter the following code to activate the new user login:</p>";

        private readonly string AuthMessageBodyAuthCode =
            @"<h4>AUTH-CODE</h4>";

        private readonly string AuthMessageBodyActivateTime =
            @"<p>This activation code will expire at: <b>ACTIVATE-TIME</b><p>";

        private readonly string AuthMessageBodyBottom =
            @"<p>Thanks and enjoy the trip!<p>
                </body>";


        private readonly string ExportNoteText = "EXPORT-NOTE";

        private readonly string ExportMessageSubject = "McBob's Books Export";

        private readonly string ExportMessageBodyTop =
            @"<body>
                <p>Please find attached the latest books read:</p>";

        private readonly string ExportMessageBodyNote =
            @"<p>EXPORT-NOTE</p>";

        private readonly string ExporthMessageBodyBottom =
            @"<p>Thanks and hope you enjoy!<p>
                </body>";


        #endregion

        #region Private data

        /// <summary>
        /// The books read database.
        /// </summary>
        private readonly BooksReadDatabase _booksReadDatabase;

        /// <summary>
        /// The books read from database.
        /// </summary>
        private ObservableCollection<BookRead> _booksReadFromDatabase;

        /// <summary>
        /// The books read from database.
        /// </summary>
        private ObservableCollection<Book> _books;

        #endregion

        #region Utility Functions

        /// <summary>
        /// Gets the providers for the books and geography data.
        /// </summary>
        /// <param name="geographyProvider">The geography data provider on exit.</param>
        /// <param name="booksReadProvider">The books data provider on exit.</param>
        /// <returns>True if successful, false otherwise.</returns>
        protected bool GetProviders(out BooksReadProvider booksReadProvider)
        {
            booksReadProvider = null;

            if (!_booksReadDatabase.ReadFromDatabase)
            {
                _booksReadDatabase.ConnectToDatabase();
            }

            if (_booksReadDatabase.ReadFromDatabase)
            {
                // Setup the providers.
                booksReadProvider = new BooksReadProvider();
                booksReadProvider.Setup(_booksReadDatabase.LoadedItems);

                return true;
            }

            return false;
        }

        #endregion

        public IEnumerable<Book> GetAllBooks()
        {
            BooksReadProvider booksReadProvider;
            _books = new ObservableCollection<Book>();

            if (GetProviders(out booksReadProvider))
            {
                foreach (var bookRead in booksReadProvider.BooksRead)
                {
                    _books.Add(new Book(bookRead));
                }
            }

            return _books;
        }

        public BooksDataUtilities(MongoDbSettings dbSettings) : base(dbSettings)
        {
            DatabaseConnectionString = dbSettings.DatabaseConnectionString;
            ExportDirectory = dbSettings.ExportDirectory;


            _booksReadFromDatabase = new ObservableCollection<BookRead>();

            if (!dbSettings.UseRemoteHost)
            {
                _booksReadDatabase = new BooksReadDatabase(DatabaseConnectionString);
            }
            else
            {
                _booksReadDatabase =
                    new BooksReadDatabase(string.Empty, false)
                    {
                        MongoClientFunc = GetRemoteConnection
                    };
                _booksReadDatabase.ConnectToDatabase();

            }
        }

    }
}
