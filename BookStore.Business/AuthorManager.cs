using BookStore.Business.Abstract;
using BookStore.DAL.Abstract;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Business
{
    public class AuthorManager : IAuthorManager
    {
        private readonly IAuthorDal _authorDal;
        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }
        public Author Add(Author author)
        {
            return _authorDal.Add(author);
        }

        public IEnumerable<Author> GetAll()
        {
            return _authorDal.GetAll();
        }

        public Author GetById(int id)
        {
            return _authorDal.GetById(id);
        }

        public Author GetError()
        {
            return _authorDal.GetError();
        }
    }
}
