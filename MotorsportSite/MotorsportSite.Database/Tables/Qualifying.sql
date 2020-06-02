CREATE TABLE [dbo].[Qualifying]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [DriverId] INT NOT NULL,
    [CalId] INT NOT NULL,
	LapTime TIME NOT NULL, 
    [Position] INT NOT NULL, 
    [TireId] INT NOT NULL,
    [TrackRecord] BIT NOT NULL DEFAULT 0
)
