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








