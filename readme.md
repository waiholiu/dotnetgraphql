Prereq

- make sure you have a sql database set up
- If you have docker, just run this to set up SQL Server in docker

docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=Password1' -p 1433:1433 -v sqlvolume:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2017-latest




Installation

in app folder
- dotnet restore
- dotnet ef database update
- dotnet run

To run it

Graphql endpoint is at Https://localhost:5001/graphql








