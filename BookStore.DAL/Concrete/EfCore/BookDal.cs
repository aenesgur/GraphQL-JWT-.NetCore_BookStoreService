using BookStore.DAL.Abstract;
using BookStore.DAL.Concrete.EfCore;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.DAL
{
    public class BookDal : IBookDal
    {
        private readonly BookStoreContext _context;
        public BookDal(BookStoreContext context)
        {
            _context = context;
        }

        public Book Add(Book model)
        {
            _context.Books.Add(model);
            _context.SaveChanges();
            return model;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books;
        }

        public IEnumerable<Book> GetAllForAuthor(int authorId)
        {
            return _context.Books.Where(x => x.AuthorId == authorId);
        }

        public IEnumerable<Book> GetAllForAuthor(int authorId, int lastAmount)
        {
            return _context.Books.Where(x => x.AuthorId == authorId)
                .Take(lastAmount);
        }

        public Book GetById(int id)
        {
            return _context.Books.SingleOrDefault(x => x.Id == id);
        }
    }
}
