using BookStore.DAL.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BookStore.DAL
{
    public class BookStoreContextFactory : IDesignTimeDbContextFactory<BookStoreContext>
    {
        public BookStoreContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<BookStoreContext>();
            var connectionString = configuration.GetConnectionString("BookStoreDb");
            builder.UseSqlServer(connectionString);

            return new BookStoreContext(builder.Options);
        }
    }
}
