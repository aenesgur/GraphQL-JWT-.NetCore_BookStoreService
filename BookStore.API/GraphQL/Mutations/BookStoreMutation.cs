using BookStore.API.GraphQL.Types.Author;
using BookStore.API.GraphQL.Types.Book;
using BookStore.Business.Abstract;
using BookStore.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.GraphQL.Mutations
{
    public class BookStoreMutation : ObjectGraphType
    {
        public BookStoreMutation(IAuthorManager authorManager, IBookManager bookManager)
        {
            Field<AuthorType>(
                "addAuthor",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AuthorInputType>> { Name = "author" }),
                resolve: context =>
                {
                    var author = context.GetArgument<Author>("author");
                    return authorManager.Add(author);
                });

            Field<BookType>(
                "addBook",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BookInputType>> { Name = "book" }),
                resolve: context =>
                {
                    var book = context.GetArgument<Book>("book");
                    return bookManager.Add(book);
                });
        }
    }
}
