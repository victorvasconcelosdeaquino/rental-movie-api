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
 