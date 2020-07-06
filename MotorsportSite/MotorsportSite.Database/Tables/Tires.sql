CREATE TABLE [dbo].[Tires]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [CompoundType] NVARCHAR(50) NOT NULL,
    [TireName] NVARCHAR(50) NOT NULL,
    [TireColour] NVARCHAR(20) NOT NULL, 
    [TireSize] DECIMAL NOT NULL,
    [Thread] NVARCHAR(50) NOT NULL,
    [DrivingCondition] NVARCHAR(50) NOT NULL,
    [GripLevel] INT NULL,
    [DurabilityLevel] INT NULL,
    [Description] NVARCHAR(max) NULL
)
