# This is a general template for writing layered applications 
# It is a combination of Monolithic Layered Architectuyre and Clean (Onion) Architecture.
# Environment & Technologies: 
    Visual Studio 2022, .Net 6.0, C# 10, Dapper 
    Minimal API + Data Access Layer

# Gytts.Home.PropertyManagement

Here are the steps:

Create first project - ASP .Net Core Web API
Project Name - Gytts.Home.PropertyManagement.API
Solution Name - Gytts.Home.PropertyManagement

Check both OpenAPI Support and Configure HTTPS 
Docker is unchcked - Investigate the effect

Create second project - SQL Server Database Project 
Project Name - Gytts.Home.PropertyManagement.Database

Note: Using this project type, we can code SQL, Name Refactoring, Deploy and Rollback and also have version controls.

Create Folder: dbo
Subfolder 1: Tables
	Add Table - Properties

Subfolder 2: StoredProcedures
	Add Stored Procedure - spProperty_GetAll, spProperty_Get, ...

Add Script (at project level) 
	Post-Deployment Script - To initialize the table(s)
	Remove '1' from default name, make it Script.PortDeployment.sql as there is only one of this type.
	
Minute: 23

Publish 	
	Edit - Browse - Local - SQL DB
	Database name: Gytts.Home.PropertyManagement
	Publish Script Name: PublishScript.sql
	Save Profile as - Goes to the project root
	Go to SQL Server explorer to see it is not there!
	Publish it
	Refresh SQL Server explorer to see it is there now!
	

Note: By default this file will not go into source control as it might have some sensitive data in it.

Minute: 27:40

Create a project - Class Library
Project Name - Gytts.Home.PropertyManagement.DataAccessLayer

Create 3 folders: Data, DataAccess, Entities

Note: At Solution level, add new item "Editor Config (.Net)", in Code style, change namespace declaration to File Scoped

Entities: Add some like PropertyEntity and so on 

Minute: 34

DataAccess: 
	Add Nuget(s) including Dapper (micro-ORM) (2.0.123), 
						   System.Data.SqlClient (4.8.3), 
						   Microsoft.Extension.Configuration.Abstraction (6.0.0)
	

Dapper is a product from a company who has made StackOverflow before.

Minute: 36:56

	Add SqlDataAccess and ISqlDataAccess classes
	
Data: 
	
	Add SqlDataAccess. Once done extract ISqlDataAccess interface from it.
	
------------------------------------
All we need to gradually add other classes to Data folder and that is all other components need to talk to.

-----------------------------------
Minimal API 
-----------------------------------

Get Connection String from DataAccess project and set it in API project (appsetting.json)
For some reasons it did not work, so I published the database project and got the connectionstr from SQL Server directly. Now it works.

Note 1: API starts with program.cs file where all its code is encapsulated in a hidden **static void main**
Note 2: Dependecy Injections are implemented using builder.Services

Add reference to DataAccess 
Add Global Using to DataAccess.Data - Do that in a separate file not programs.cs. Add a new file called GlobalUsings.cs
