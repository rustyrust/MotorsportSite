CREATE TABLE [dbo].[Qualifying]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [DriverId] INT NOT NULL,
    [CalId] INT NOT NULL,
	Q1Time NVARCHAR(15) NULL, 
    Q2Time NVARCHAR(15) NULL, 
    Q3Time NVARCHAR(15) NULL, 
    Laps INT NULL,
    [Position] INT NOT NULL, 
    [TireId] INT NOT NULL,
    [TrackRecord] BIT NOT NULL DEFAULT 0
)
