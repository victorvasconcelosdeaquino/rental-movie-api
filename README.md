# rental-movie-api

### Requirements
- [.Net Framework 5.0](https://dotnet.microsoft.com/pt-br/download/dotnet/5.0)
- [SqlServer Express](https://go.microsoft.com/fwlink/p/?linkid=2216019&clcid=0x416&culture=pt-br&country=br)
- [EF Core Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

### Installation
1. Install SQL Server Express
2. Connect to Server using Windows Authentication
3. Run the scripts below:
```
create database db_rental;

USE db_rental;
GO
CREATE LOGIN [rental] WITH PASSWORD=N'rental@123', DEFAULT_DATABASE=[db_rental], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
USE [db_rental]
GO
CREATE USER [rental] FOR LOGIN [rental]
GO
USE [db_rental]
GO
ALTER USER [rental] WITH DEFAULT_SCHEMA=[dbo]
GO
USE [db_rental]
GO
ALTER ROLE [db_datareader] ADD MEMBER [rental]
GO
USE [db_rental]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [rental]
GO
USE [db_rental]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [rental]
GO
USE [db_rental]
GO
ALTER ROLE [db_owner] ADD MEMBER [rental]
GO
 ```
4. Disconnect and connect to the server using SQL Server Authentication (user: rental, pass: rental@123). Note: There is a possibility you may not able to connect using SQL Server Authentication if the option "Server Authentication 'SQL Server and Windows Authentication mode'" isn't enabled on Server Properties

### Migration
1. Clone the repository to your computer
2. Open the Command/Power Shell and navigate to the .csproj file
3. Type "dotnet ef" to verify if EF Core Tools are installed correctly
4. Type "dotnet ef migrations add -name your migration-". The project will be built.
5. Type "dotnet ef database update". The project will be built.

### Authentication
1. Running the project, you can only request any endpoint after authentication.
2. The endpoint "/api/auth" must be requested with the parameters "userName": "vaquino", "password": "americas123" (later I`ll move to the database or some storage key).
3. This request will return a token. I'll need to put on the "Authorize" option like this: Bearer <token>.
4. After that you'll be able to request any endpoint.

