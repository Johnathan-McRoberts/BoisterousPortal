using System.Collections.ObjectModel;
using BooksDbReader.Books;

namespace BooksDbReader.Interfaces
{
    /// <summary>
    /// The Book Read provider interface.
    /// </summary>
    public interface IBooksReadProvider
    {
        /// <summary>
        /// Gets the books.
        /// </summary>
        ObservableCollection<BookRead> BooksRead { get; }
    }
}
