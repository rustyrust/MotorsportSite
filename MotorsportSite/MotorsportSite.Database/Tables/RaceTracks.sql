CREATE TABLE [dbo].[RaceTracks]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Location] NVARCHAR(50) NOT NULL, 
    [Country] NVARCHAR(50) NOT NULL, 
    [TrackName] NVARCHAR(50) NOT NULL, 
    [TrackLenght] INT NOT NULL, 
    [Laps] INT NOT NULL, 
    [NumberOfCorners] INT NOT NULL, 
    [IsClockwise] BIT NOT NULL DEFAULT 1, 
    [IsDeleted] BIT NOT NULL DEFAULT 0
)
