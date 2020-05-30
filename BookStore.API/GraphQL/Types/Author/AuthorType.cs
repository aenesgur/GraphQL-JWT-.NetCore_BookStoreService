using BookStore.API.GraphQL.Types.Book;
using BookStore.Business.Abstract;
using GraphQL.Types;

namespace BookStore.API.GraphQL.Types.Author
{
    public class AuthorType : ObjectGraphType<BookStore.Entities.Author>
    {
        public AuthorType(IBookManager bookManager)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Surname);
            Field(x => x.Citizen);
            Field<ListGraphType<BookType>>(
                "books",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "piece" }),
                resolve: context => {
                    var filter = context.GetArgument<int?>("piece");
                    return filter != null
                        ? bookManager.GetAllForAuthor(context.Source.Id, filter.Value)
                        : bookManager.GetAllForAuthor(context.Source.Id);
                    });
        }
    }
}
