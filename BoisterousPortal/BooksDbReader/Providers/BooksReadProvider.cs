using BooksDbReader.Books;
using BooksDbReader.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDbReader.Providers
{
    public class BooksReadProvider : IBooksReadProvider
    {
        /// <summary>
        /// Gets the books.
        /// </summary>
        public ObservableCollection<BookRead> BooksRead { get; private set; }

        public void Setup(IList<BookRead> books)
        {

            BooksRead.Clear();
            foreach (BookRead book in books.OrderBy(x => x.Date))
                BooksRead.Add(book);

        }

        public BooksReadProvider()
        {
            BooksRead = new ObservableCollection<BookRead>();
        }
    }
}
