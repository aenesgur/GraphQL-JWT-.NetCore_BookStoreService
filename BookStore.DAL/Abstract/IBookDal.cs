using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DAL.Abstract
{
    public interface IBookDal : IEntityDal<Book>
    {
        IEnumerable<Book> GetAllForAuthor(int authorId);
        IEnumerable<Book> GetAllForAuthor(int authorId, int lastAmount);
    }
}
