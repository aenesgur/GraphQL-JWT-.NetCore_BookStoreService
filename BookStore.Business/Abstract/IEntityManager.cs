using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Business.Abstract
{
    public interface IEntityManager<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T model);
    }
}
