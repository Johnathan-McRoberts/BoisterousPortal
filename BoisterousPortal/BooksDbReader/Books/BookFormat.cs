using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDbReader.Books
{
    /// <summary>
    /// The book format.
    /// </summary>
    public enum BookFormat
    {
        /// <summary>
        /// The book.
        /// </summary>
        Book = 1,

        /// <summary>
        /// The comic.
        /// </summary>
        Comic = 2,

        /// <summary>
        /// The audio.
        /// </summary>
        Audio = 3
    }
}