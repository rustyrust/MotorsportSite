CREATE TABLE [dbo].[TeamsPowerUnit]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TeamId] IMAGE NOT NULL, 
    [ManufacturerId] INT NOT NULL, 
    [StartDate] DATETIME2 NOT NULL, 
    [EndDate] DATETIME2 NOT NULL
)
