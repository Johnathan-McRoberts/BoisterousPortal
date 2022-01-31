using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BooksRelational.Data
{
    public class BooksRelationalContextFactory : IDesignTimeDbContextFactory<BooksRelationalContext>
    {
        public BooksRelationalContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BooksRelationalContext>();
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\jonathan.Mcroberts\Documents\MyDbs\PortalReading.db");

            return new BooksRelationalContext(optionsBuilder.Options);
        }
    }
}
