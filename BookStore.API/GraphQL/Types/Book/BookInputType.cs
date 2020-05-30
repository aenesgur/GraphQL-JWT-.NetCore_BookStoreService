using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.GraphQL.Types.Book
{
    public class BookInputType : InputObjectGraphType
    {
        public BookInputType()
        {
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("description");
            Field<StringGraphType>("publisher");
            Field<BooleanGraphType>("isStock");
            Field<DecimalGraphType>("price");
            Field<IntGraphType>("authorId");

        }
    }
}
