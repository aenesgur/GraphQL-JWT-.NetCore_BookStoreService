using BookStore.Business.Abstract;
using BookStore.DAL.Abstract;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Business
{
    public class BookManager : IBookManager
    {
        private readonly IBookDal _bookDal;
        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public Book Add(Book model)
        {
            return _bookDal.Add(model);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookDal.GetAll();
        }

        public IEnumerable<Book> GetAllForAuthor(int authorId)
        {
            return _bookDal.GetAllForAuthor(authorId);
        }

        public IEnumerable<Book> GetAllForAuthor(int authorId, int lastAmount)
        {
            return _bookDal.GetAllForAuthor(authorId,lastAmount);
        }

        public Book GetById(int id)
        {
            return _bookDal.GetById(id);
        }
    }
}
