CREATE TABLE [dbo].[DriverRacingLicensePoints]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	DriverPenaltyId INT NOT NULL,
	Points INT NOT NULL DEFAULT 0,
	CONSTRAINT [FK_DriverRacingLicensePoints_DriverPenaltyId] FOREIGN KEY([DriverPenaltyId]) REFERENCES [dbo].[DriverPenalties]([Id]),

)
