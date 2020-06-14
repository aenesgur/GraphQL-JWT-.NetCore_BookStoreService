### Book Store Service with GraphQL

GraphQL technology was combined with .Net Core 3.1 and a simple Book Store service was developed. GraphiQL interface added to run our queries which is default. Query and Mutations queries have been added and SeedData added. Adding Book and Author in the associated database can be inserted with mutations. Just change the ConnectionString and run :) 
#### Sample queries:
> $ Get all authors. You can modify it according to the variable you want to receive
```sh
{
  all_authors{
    name
    surname
    citizen
      books{
	name
      	description
      	isStock
      	price
        authorId
      }
  }
}
```
> $ Filtering the number of books in the book list
```sh
{
  all_authors{
    name
    surname
    citizen
      books(piece : 1){
	name
      	description
      	isStock
      	price
        authorId
      }
  }
}
```

> $ Get author by id and filtering the number of books in the book list
```sh
{
  author_by_id (id: 2){
    name
    surname
    citizen
      books(piece : 1) {
	name
      	description
      }
  }
}
```

> $ Get book by id
```sh
{
  book_by_id(id : 2){
    name,
    description,
    isStock
  }
}
```
> $ Add author with mutation. After adding, we call Id and Name to be sure added to database
```sh
mutation ($author: AuthorInputType!) {
  addAuthor(author: $author) {
    id
    name
  }
}
(Query of under the this line should added QUERY VARIABLES region)
{
  "author": {
    "name": "Dan",
    "surname": "Brown",
    "citizen": "USA"
  }
}
```
> $ Add book with mutation. After adding, we call Id and Name to be sure added to database
```sh
mutation ($book: BookInputType!) {
  addBook(book: $book) {
    id
    name
  }
}
(Query of under the this line should added QUERY VARIABLES region)
{
  "book": {
    "name": "The Da Vinci Code",
    "description": "The Da Vinci Code Descripion",
    "publisher": "Alfa",
    "isStock": true,
    "price": 50,
    "authorId": 6
  }
}
```
