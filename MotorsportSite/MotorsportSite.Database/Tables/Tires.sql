CREATE TABLE [dbo].[Tires]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [CompoundType] NVARCHAR(50) NOT NULL, 
    [TireColour] NVARCHAR(20) NOT NULL, 
    [TierSize] DECIMAL NOT NULL
)
