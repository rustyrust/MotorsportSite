CREATE TABLE [dbo].[DriverMarket]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [TeamId] INT NOT NULL, 
    [DriverId] INT NOT NULL, 
    [RacingCategoryId] INT NOT NULL, 
    [StartDate] DATETIME2 NOT NULL, 
    [EndDate] DATETIME2 NULL
    CONSTRAINT [FK_DriverMarket_Teams] FOREIGN KEY([TeamId]) REFERENCES [dbo].[Teams]([Id]),
    CONSTRAINT [FK_DriverMarket_Drivers] FOREIGN KEY([DriverId]) REFERENCES [dbo].[Drivers]([Id])
)
