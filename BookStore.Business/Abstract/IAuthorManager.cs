using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Business.Abstract
{
    public interface IAuthorManager : IEntityManager<Author>
    {
        Author GetError();
    }
}
