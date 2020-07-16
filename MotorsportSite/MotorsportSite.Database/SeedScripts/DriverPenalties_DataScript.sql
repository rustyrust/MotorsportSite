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

SET IDENTITY_INSERT [dbo].[DriverPenalties] ON;


MERGE INTO [dbo].[DriverPenalties] AS T
    USING (        
           VALUES (1,   8,  111, 'For ignoring the yellow flag, 3 place grid penalty',  2),
                  (2,   4,  114, 'Penalised 3 grid places for impeding Kvyat during qualifying', 2)

          )
    AS S (Id, DriverId, CalId, [Description], PenaltyId)
    ON T.Id = S.Id
WHEN MATCHED THEN
UPDATE SET
    CalId = S.CalId,
    DriverId = S.DriverId,
    [Description] = S.[Description],
    PenaltyId = S.PenaltyId
WHEN NOT MATCHED THEN
    INSERT (Id, DriverId, CalId, [Description], PenaltyId)
    VALUES (S.Id, S.DriverId, S.CalId, S.[Description], S.PenaltyId);


SET IDENTITY_INSERT [dbo].[DriverPenalties] OFF