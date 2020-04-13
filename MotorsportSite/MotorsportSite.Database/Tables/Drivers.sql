CREATE TABLE [dbo].[Drivers]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [DriverNumber] INT NOT NULL, 
    [DOB] DATETIME2 NOT NULL, 
    [Nationality] NVARCHAR(50) NOT NULL, 
    [IsRetired] BIT NOT NULL DEFAULT 0
)
