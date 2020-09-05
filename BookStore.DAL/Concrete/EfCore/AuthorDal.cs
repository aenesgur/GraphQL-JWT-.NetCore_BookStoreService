using BookStore.DAL.Abstract;
using BookStore.DAL.Concrete.EfCore;
using BookStore.Entities;
using BookStore.Log.Abstract;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.DAL
{
    public class AuthorDal : IAuthorDal
    {
        private readonly BookStoreContext _context;
        private readonly ILogService _logger;
        public AuthorDal(BookStoreContext context, ILogService logger)
        {
            _context = context;
            _logger = logger;
        }
        public Author Add(Author model)
        {
            try
            {
                _context.Authors.Add(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
           
        }

        public IEnumerable<Author> GetAll()
        {
            try
            {
                return _context.Authors;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
            
        }

        public Author GetById(int id)
        {
            try
            {
                return _context.Authors.SingleOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
            
        }

        public Author GetError()
        {
            try
            {
                if (2>1)
                {
                    throw new Exception("Opps! are you serios?");
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get Error method worked wrongly");
                return null;
            }
        }
    }
}
