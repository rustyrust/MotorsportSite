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

SET IDENTITY_INSERT [dbo].[DriverMarket] ON;


MERGE INTO [dbo].[DriverMarket] AS T
    USING (
           VALUES (1,  2,  1,  1, '20130101', '20191201'),
                  (2,  2,  2,  1, '20170101', '20201201')
          )
    AS S (Id, TeamId, DriverId, RacingCategoryId, StartDate, EndDate)
    ON T.Id = S.Id
WHEN MATCHED THEN
    UPDATE SET
    TeamId = S.TeamId,
    DriverId = S.DriverId,
    RacingCategoryId = S.RacingCategoryId,
    StartDate = S.StartDate,
    EndDate = S.EndDate
WHEN NOT MATCHED THEN
    INSERT (Id, TeamId, DriverId, RacingCategoryId, StartDate, EndDate)
    VALUES (S.Id, S.TeamId, S.DriverId, S.RacingCategoryId, S.StartDate, S.EndDate);


SET IDENTITY_INSERT [dbo].[DriverMarket] OFF