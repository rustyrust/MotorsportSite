CREATE TABLE [dbo].[Points]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Points] DECIMAL NOT NULL, 
    [Position] INT NOT NULL, 
    [AllicationFor] NVARCHAR(20) NOT NULL
)
