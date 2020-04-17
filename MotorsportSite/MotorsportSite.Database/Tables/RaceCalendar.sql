CREATE TABLE [dbo].[RaceCalendar]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [TrackId] INT NOT NULL, 
    [StartDate] DATETIME2 NOT NULL, 
    [EndDate] DATETIME2 NOT NULL, 
    [EventName] NVARCHAR(50) NOT NULL, 
    [Category] INT NOT NULL
    CONSTRAINT [FK_RaceCalendar_TrackId] FOREIGN KEY([TrackId]) REFERENCES [dbo].[RaceTracks]([Id])
)
