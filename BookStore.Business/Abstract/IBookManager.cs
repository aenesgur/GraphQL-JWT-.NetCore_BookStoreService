using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Business.Abstract
{
    public interface IBookManager : IEntityManager<Book>
    {
        IEnumerable<Book> GetAllForAuthor(int authorId);
        IEnumerable<Book> GetAllForAuthor(int authorId, int lastAmount);
    }
}
