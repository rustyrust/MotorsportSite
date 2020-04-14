CREATE TABLE [dbo].[TeamPrinciple]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Nationality] NVARCHAR(50) NOT NULL, 
    [DOB] DATETIME2 NOT NULL, 
    [EntryDate] DATETIME2 NOT NULL, 
    [LeaveDate] DATETIME2 NULL
)
