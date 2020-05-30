using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DAL.Abstract
{
    public interface IEntityDal<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T model);
    }
}
