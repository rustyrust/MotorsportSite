CREATE TABLE [dbo].[Teams]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [TeamName] NVARCHAR(100) NOT NULL, 
    [EntryDate] DATETIME2 NOT NULL, 
    [LeaveDate] DATETIME2 NULL, 
    [PrimaryColourName] NVARCHAR(255) NOT NULL,
    [PrimaryColour] NVARCHAR(50) NULL, 
    [SecondaryColourName] NVARCHAR(50) NULL, 
    [SecondaryColour] NVARCHAR(50) NULL
)
