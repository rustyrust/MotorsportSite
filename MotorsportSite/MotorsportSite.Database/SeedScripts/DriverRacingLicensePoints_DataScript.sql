/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

SET IDENTITY_INSERT [dbo].[DriverRacingLicensePoints] ON;


MERGE INTO [dbo].[DriverRacingLicensePoints] AS T
    USING ( 
           VALUES (1, 1, 2)
          )
    AS S (Id, DriverPenaltyId, Points)
    ON T.Id = S.Id
WHEN MATCHED THEN
UPDATE SET
    DriverPenaltyId = S.DriverPenaltyId,
    Points = S.Points
WHEN NOT MATCHED THEN
    INSERT (Id, DriverPenaltyId, Points)
    VALUES (S.Id, S.DriverPenaltyId, S.Points);


SET IDENTITY_INSERT [dbo].[DriverRacingLicensePoints] OFF