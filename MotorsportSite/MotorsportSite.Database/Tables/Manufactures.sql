CREATE TABLE [dbo].[Manufactures]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [EntryDate] DATETIME2 NOT NULL, 
    [LeaveDate] DATETIME2 NOT NULL
)
