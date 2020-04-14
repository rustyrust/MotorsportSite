CREATE TABLE [dbo].[Drivers]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [CatagoryId] INT NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [ShortName] NVARCHAR(10) NOT NULL,
    [DriverNumber] INT NOT NULL, 
    [DOB] DATETIME2 NOT NULL, 
    [Country] NVARCHAR(50) NOT NULL, 
    [PlaceOfBirth] NVARCHAR(50) NOT NULL    
)
