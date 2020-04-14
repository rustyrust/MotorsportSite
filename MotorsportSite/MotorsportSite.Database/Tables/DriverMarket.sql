CREATE TABLE [dbo].[DriversTeamMovement]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TeamId] INT NOT NULL, 
    [DriverId] INT NOT NULL, 
    [RacingCategoryId] INT NOT NULL, 
    [StartDate] DATETIME2 NOT NULL, 
    [EndDate] DATETIME2 NULL
    CONSTRAINT [FK_Team] FOREIGN KEY([TeamId]) REFERENCES [dbo].[Teams]([Id]),
    CONSTRAINT [FK_Drivers] FOREIGN KEY([DriverId]) REFERENCES [dbo].[Drivers]([Id])
)
