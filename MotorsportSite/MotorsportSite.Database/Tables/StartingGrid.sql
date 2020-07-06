CREATE TABLE [dbo].[StartingGrid]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[DriverId] INT NOT NULL,
	[CalId] INT NOT NULL,
	[Position] INT NOT NULL,
	[TireId] INT NOT NULL,
	CONSTRAINT [StartingGrid_FK_Drivers] FOREIGN KEY(DriverId) REFERENCES [dbo].[Drivers]([Id]),
    CONSTRAINT [StartingGrid_FK_RaceCalendar] FOREIGN KEY(CalId) REFERENCES [dbo].[RaceCalendar]([Id]),
	CONSTRAINT [StartingGrid_FK_Tires] FOREIGN KEY(TireId) REFERENCES [dbo].[Tires]([Id])
)
