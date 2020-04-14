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
SET IDENTITY_INSERT [dbo].[TeamsPowerUnit] ON;


MERGE INTO [dbo].[TeamsPowerUnit]AS T
    USING (
           VALUES (1,  1,  1,  '20190101', NULL),
                  (2,  1,  4,  '20160101', '20181101'),
                  (3,  2,  3,  '19900101', NULL)
          )
    AS S (Id, TeamId, ManufacturerId, StartDate, EndDate)
    ON T.Id = S.Id
WHEN MATCHED THEN
    UPDATE SET
    StartDate = S.StartDate,
    EndDate = S.EndDate
WHEN NOT MATCHED THEN
    INSERT (Id, TeamId, ManufacturerId, StartDate, EndDate)
    VALUES (S.Id, S.TeamId, S.ManufacturerId, S.StartDate, S.EndDate);


SET IDENTITY_INSERT [dbo].[TeamsPowerUnit] OFF