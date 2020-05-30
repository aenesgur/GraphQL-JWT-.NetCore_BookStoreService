using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.GraphQL.Types.Book
{
    public class BookType : ObjectGraphType<BookStore.Entities.Book>
    {
        public BookType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Description);
            Field(x => x.Publisher);
            Field(x => x.isStock);
            Field(x => x.Price);
            Field(x => x.AuthorId);

        }
    }
}
