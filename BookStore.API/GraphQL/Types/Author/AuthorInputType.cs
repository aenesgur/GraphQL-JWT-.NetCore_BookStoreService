using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.GraphQL.Types.Author
{
    public class AuthorInputType : InputObjectGraphType
    {
        public AuthorInputType()
        {
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("surname");
            Field<StringGraphType>("citizen");
        }
       
    }
}
