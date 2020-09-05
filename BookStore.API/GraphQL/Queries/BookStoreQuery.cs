using BookStore.API.GraphQL.Types.Author;
using BookStore.API.GraphQL.Types.Book;
using BookStore.Business.Abstract;
using GraphQL.Types;

namespace BookStore.API.GraphQL.Queries
{
    public class BookStoreQuery : ObjectGraphType
    {
        public BookStoreQuery(IAuthorManager authorManager, IBookManager bookManager)
        {
            Field<ListGraphType<AuthorType>>(
                "all_authors",
                resolve: context => authorManager.GetAll());

            Field<AuthorType>(
                "author_by_id",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => authorManager.GetById(context.GetArgument<int>("id")));

            Field<AuthorType>(
                "get_error",
                resolve: context => authorManager.GetError());

            Field<ListGraphType<BookType>>(
                "all_books",
                resolve: contex => bookManager.GetAll());

            Field<BookType>(
                "book_by_id",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => bookManager.GetById(context.GetArgument<int>("id")));
        }
    }
}
