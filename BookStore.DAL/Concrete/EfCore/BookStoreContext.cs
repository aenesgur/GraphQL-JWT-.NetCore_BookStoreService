using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DAL.Concrete.EfCore
{
    public class BookStoreContext : DbContext 
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
