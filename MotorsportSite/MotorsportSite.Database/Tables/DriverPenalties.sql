CREATE TABLE [dbo].[DriverPenalties]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	DriverId INT NOT NULL,
	CalId INT NOT NULL,
	[Description] NVARCHAR(MAX) NULL,
	PenaltyId INT NOT NULL
	CONSTRAINT [FK_DriverPenalties_DriverId] FOREIGN KEY([DriverId]) REFERENCES [dbo].[Drivers]([Id]),
	CONSTRAINT [FK_DriverPenalties_CalId] FOREIGN KEY([CalId]) REFERENCES [dbo].[RaceCalendar]([Id]),
	CONSTRAINT [FK_DriverPenalties_PenaltyId] FOREIGN KEY([PenaltyId]) REFERENCES [dbo].[Penalties]([Id])
)
