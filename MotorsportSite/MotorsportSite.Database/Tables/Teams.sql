CREATE TABLE [dbo].[Teams]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TeamName] NVARCHAR(100) NOT NULL, 
    [EntryDate] DATETIME2 NOT NULL, 
    [LeaveDate] DATETIME2 NULL, 
    [TeamColours] NVARCHAR(255) NOT NULL
)
