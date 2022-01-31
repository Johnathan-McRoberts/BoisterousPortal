using Microsoft.EntityFrameworkCore;
using BooksRelational.Models;

namespace BooksRelational.Data
{
    public class BooksRelationalContext : DbContext
    {
        public BooksRelationalContext(DbContextOptions<BooksRelationalContext> options)
        : base(options)
        { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source=C:\Users\jonathan.Mcroberts\Documents\MyDbs\PortalReading.db");
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<BookRead> BooksRead { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
