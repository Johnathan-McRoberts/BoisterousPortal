﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDbReader.Books
{
    public class Book
    {
        /// <summary>
        /// Gets or sets the unique entity identifier string.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the date string.
        /// </summary>
        public string DateString { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the pages.
        /// </summary>
        public int Pages { get; set; }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the nationality.
        /// </summary>
        public string Nationality { get; set; }

        /// <summary>
        /// Gets or sets the original language.
        /// </summary>
        public string OriginalLanguage { get; set; }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public string[] Tags { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Gets or sets the book format.
        /// </summary>
        public string Format { get; set; }

        public Book()
        {
            Id = string.Empty;
            DateString = string.Empty;
            Date = DateTime.Now;
            Author = string.Empty;
            Title = string.Empty;
            Pages = 0;
            Note = string.Empty;
            Nationality = string.Empty;
            OriginalLanguage = string.Empty;
            ImageUrl = string.Empty;
            User = string.Empty;
            Format = string.Empty;
            Tags = new string[] { };
        }

        public Book(Book book)
        {
            Id = book.Id;
            DateString = book.DateString;
            Date = book.Date;
            Author = book.Author;
            Title = book.Title;
            Pages = book.Pages;
            Note = book.Note;
            Nationality = book.Nationality;
            OriginalLanguage = book.OriginalLanguage;
            ImageUrl = book.ImageUrl;
            User = book.User;
            Format = book.Format;
            Tags = new string[book.Tags.Length];
            for (int i = 0; i < book.Tags.Length; i++)
            {
                Tags[i] = book.Tags[i];
            }
        }

        public Book(BookRead book)
        {
            Id = book.Id.ToString();
            DateString = book.DateString;
            Date = book.Date;
            Author = book.Author;
            Title = book.Title;
            Pages = book.Pages;
            Note = book.Note;
            Nationality = book.Nationality;
            OriginalLanguage = book.OriginalLanguage;
            ImageUrl = book.ImageUrl;
            User = book.User;
            Format = book.Format.ToString();
            Tags = new string[book.Tags.Count];
            for (int i = 0; i < book.Tags.Count; i++)
            {
                Tags[i] = book.Tags[i];
            }
        }

    }
}
