CREATE TABLE [dbo].[Points]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Points] DECIMAL NOT NULL, 
    [Position] INT NOT NULL, 
    [AllicationFor] NVARCHAR(20) NOT NULL, 
    [StartYear] INT NOT NULL, 
    [EndYear] INT NULL
)
