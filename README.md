### Book Store Service with GraphQL, JWT, Serilog, Kibana, Elasticsearch 

GraphQL, JWT, Serilog(with Kibana and Elasticsearch to monitoring logs) technologies was combined with .Net Core 3.1 and a simple Book Store service was developed. Query and Mutations queries have been added and SeedData added. Adding Book and Author in the associated database can be inserted with mutations. Just change the ConnectionString and run :) 

#### Monitoring the logs with Kibana
###### Before starting the app, enter the project file and write "docker-compose up" in command line. If you have Elasticsearch and Kibana images in your Docker, it will run. If not, it will pull from DockerHub, install and run. After the docker images up, you can go to these links from browser to check if its run correctly  http://localhost:9200/ , http://localhost:5601/ . After you run the project you can set the Index name from Manage Space and then Index pattern in Kibana and monitor the logs in Discover section 
![kibana-monitoring](https://user-images.githubusercontent.com/47754791/92304194-69ebbd00-ef84-11ea-86b4-6dfebbb59f41.PNG)

#### Authentication:
> $ Register to identity server. Post request to "http://localhost:54811/api/authentication/register"
```sh
{
    "Email":"info@info.com",
    "Password":"Info.123",
    "ConfirmPassword":"Info.123"
}
```
![register](https://user-images.githubusercontent.com/47754791/84596475-b1bbe600-ae66-11ea-8397-a287bcc9b36e.PNG)

> $ Login to identity server. Post request to "http://localhost:54811/api/authentication/login"  
```sh
{
    "Email":"info@info.com",
    "Password":"Info.123"
}
```
![login](https://user-images.githubusercontent.com/47754791/84596524-f9427200-ae66-11ea-98d4-166a6b1d7253.PNG)

#### Sample queries:

###### We will have a token in response After we get token, we can easily access datas with Graphql queries. In Postman, enter Authorization field and change type with "Bearer Token" and paste our token which we got after login's response. Set url with  "http://localhost:54811/graphql/" and Post request. After that try queries which I explain and wrote belows.
![Auth](https://user-images.githubusercontent.com/47754791/84596596-5e966300-ae67-11ea-8177-a323e0537884.PNG)
![queryWithJwt](https://user-images.githubusercontent.com/47754791/84596613-6eae4280-ae67-11ea-9b38-a38ee723c5ce.PNG)

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
(Query of under the this line should added GRAPHQL VARIABLES region)
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
(Query of under the this line should added GRAPHQL VARIABLES region)
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
