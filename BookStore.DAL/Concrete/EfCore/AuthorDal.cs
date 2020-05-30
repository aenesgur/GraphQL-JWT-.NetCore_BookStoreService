using BookStore.DAL.Abstract;
using BookStore.DAL.Concrete.EfCore;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.DAL
{
    public class AuthorDal : IAuthorDal
    {
        private readonly BookStoreContext _context;
        public AuthorDal(BookStoreContext context)
        {
            _context = context;
        }
        public Author Add(Author model)
        {
            _context.Authors.Add(model);
            _context.SaveChanges();
            return model;
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors;
        }

        public Author GetById(int id)
        {
            return _context.Authors.SingleOrDefault(x => x.Id == id);
        }
    }
}
