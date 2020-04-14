CREATE TABLE [dbo].[TeamsPowerUnit]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [TeamId] INT NOT NULL, 
    [ManufacturerId] INT NOT NULL, 
    [StartDate] DATETIME2 NOT NULL, 
    [EndDate] DATETIME2 NULL,
    CONSTRAINT [FK_Teams] FOREIGN KEY([TeamId]) REFERENCES [dbo].[Teams]([Id]),
    CONSTRAINT [FK_Manufactures] FOREIGN KEY([ManufacturerId]) REFERENCES [dbo].[Manufactures]([Id])
)
