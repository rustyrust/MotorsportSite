CREATE TABLE [dbo].[TeamPrincipleMarket]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [TeamId] INT NOT NULL,
    [TeamPrincipleId] INT NOT NULL, 
    [RacingCategoryId] INT NOT NULL, 
    [StartDate] DATETIME2 NOT NULL, 
    [EndDate] DATETIME2 NULL
    CONSTRAINT [FK_TeamPrincipleMarket_TeamPrinciple] FOREIGN KEY([TeamPrincipleId]) REFERENCES [dbo].[TeamPrinciple]([Id]),
    CONSTRAINT [FK_TeamPrincipleMarket_Teams] FOREIGN KEY([TeamId]) REFERENCES [dbo].[Teams]([Id]),
)
