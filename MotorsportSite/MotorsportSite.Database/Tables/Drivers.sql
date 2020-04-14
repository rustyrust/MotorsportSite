﻿CREATE TABLE [dbo].[Drivers]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [ShortName] NVARCHAR(10) NOT NULL,
    [DriverNumber] INT NOT NULL, 
    [DOB] DATETIME2 NOT NULL, 
    [Nationality] NVARCHAR(50) NOT NULL, 
    [CatagoryId] INT NOT NULL,
    [EntryDate] DATETIME2 NOT NULL, 
    [LeaveDate] DATETIME2 NULL
)
