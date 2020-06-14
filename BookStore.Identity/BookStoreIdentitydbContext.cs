using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Identity
{
    public class BookStoreIdentitydbContext : IdentityDbContext
    {
        public BookStoreIdentitydbContext(DbContextOptions<BookStoreIdentitydbContext> options) : base(options)
        {

        }
    }
}
