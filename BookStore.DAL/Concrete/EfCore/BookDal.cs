using BookStore.DAL.Abstract;
using BookStore.DAL.Concrete.EfCore;
using BookStore.Entities;
using BookStore.Log.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.DAL
{
    public class BookDal : IBookDal
    {
        private readonly BookStoreContext _context;
        private readonly ILogService _logger;
        public BookDal(BookStoreContext context, ILogService logger)
        {
            _context = context;
            _logger = logger;
        }

        public Book Add(Book model)
        {
            try
            {
                _context.Books.Add(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
           
        }

        public IEnumerable<Book> GetAll()
        {
            try
            {
                return _context.Books;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null; 
            }
            
        }

        public IEnumerable<Book> GetAllForAuthor(int authorId)
        {
            try
            {
                return _context.Books.Where(x => x.AuthorId == authorId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
           
        }

        public IEnumerable<Book> GetAllForAuthor(int authorId, int lastAmount)
        {
            try
            {
                return _context.Books.Where(x => x.AuthorId == authorId)
                .Take(lastAmount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
            
        }

        public Book GetById(int id)
        {
            try
            {
                return _context.Books.SingleOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
            
        }
    }
}
