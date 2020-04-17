CREATE TABLE [dbo].[RaceResults]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [TrackId] INT NOT NULL, 
    [DriverId] INT NOT NULL, 
    [PointsId] INT NOT NULL, 
    [IsChampion] BIT NOT NULL DEFAULT 0, 
    [LapsCompleted] INT NOT NULL, 
    [NumStops] INT NOT NULL, 
    [FastestLap] BIT NOT NULL DEFAULT 0
    CONSTRAINT [FK_RaceResults_TrackId] FOREIGN KEY([TrackId]) REFERENCES [dbo].[RaceTracks]([Id]),
    CONSTRAINT [FK_RaceResults_DriverId] FOREIGN KEY([DriverId]) REFERENCES [dbo].[Drivers]([Id]),
    CONSTRAINT [FK_RaceResults_PointsId] FOREIGN KEY([PointsId]) REFERENCES [dbo].[Points]([Id])
)
