CREATE TABLE [dbo].[Teams]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [PUId] INT NOT NULL,
    [TeamPrincipleId] INT NOT NULL,
    [TeamName] NVARCHAR(100) NOT NULL, 
    [EntryDate] DATETIME2 NOT NULL, 
    [LeaveDate] DATETIME2 NULL, 
    [Livery] NVARCHAR(255) NOT NULL 
    CONSTRAINT [FK_TeamsPowerUnit] FOREIGN KEY([PUId]) REFERENCES [dbo].[TeamsPowerUnit]([Id]),
    CONSTRAINT [FK_TeamPrinciple] FOREIGN KEY([TeamPrincipleId]) REFERENCES [dbo].[TeamPrinciple]([Id])
)
