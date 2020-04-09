CREATE TABLE [dbo].[Drivers]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [DriverNumber] INT NOT NULL, 
    [DOB] DATETIME2 NOT NULL, 
    [Nationality] NVARCHAR(50) NOT NULL
)
