**What is this?**

This is a sample project to determine how to implement a GraphQL server in .NET core 3.1. In particular, I really wanted to demonstrate how to use the DataLoader pattern along with Entity Framework to access the databases efficiently (using EF as your data provider and not using DataLoader pattern results in a n+1 problem)

I'm using
- GraphQL.NET library
- ASP.NET Web API
- .NET Core 3.1
- Linux for SQL Server docker image (although you can just use any SQL instance)
- Entity Framework Core

The database structure is very simple. It has 3 tables - Authors, Books and SalesInvoices.
An Author has many books and books have many salesinvoices.

The point of this project is for you to quickly create a GraphQL server and then quickly fire off queries on it. One nice thing to do is to also profile the queries in SQL Server to see what they are doing.

**Prereq**

- make sure you have a sql database set up
- If you have docker, just run this to set up SQL Server in docker. Otherwise just run it in whatever sql instance you have and change the connection string

docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=Password1' -p 1433:1433 -v sqlvolume:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2017-latest


**Installation**

in app folder
- dotnet restore
- dotnet ef database update
- dotnet run

**To run it**

Navigate to https://localhost:5001/testdata and this will seed data for your site (will also clear your existing data so be carefu)

Graphql endpoint is at Https://localhost:5001/graphql

You can just go there and use the graphiql IDE but it's pretty crap, I would say get a chrome extension called Altair which is better.

**some cool queries**

simple - just grab the authors

    query{
    getAuthors{
        dateOfBirth
        id
        name
    }
    }

a few tables - this will grab all the authors, show some info about their books and then information about the sales of each book

    query{
    getAuthors{
        dateOfBirth
        id
        name
        books{
        dateOfPublication
        id
        salesInvoices{
            customerName
        }
        }
    }
    }

some cooler things you can do - grab 5 books, show the author of each book, show all the other books each author has written. 
Also, for the original 5 books, show all the sales for them

    query{
    getBooks(first: 5){
        author
        {
        name
        books
        {
            title
            id
        }
        }
        dateOfPublication
        id
            salesInvoices{
        customerName
        }
        title
    }
    }








