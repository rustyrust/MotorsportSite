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

SET IDENTITY_INSERT [dbo].[RaceCalendar] ON;


MERGE INTO [dbo].[RaceCalendar] AS T
    USING (
           VALUES (1,  1,  '20190315',  '20190315',  'FP1',        1),
                  (2,  1,  '20190315',  '20190315',  'FP2',        1),
                  (3,  1,  '20190316',  '20190316',  'FP3',        1),
                  (4,  1,  '20190316',  '20190316',  'Qualifying', 1),
                  (5,  1,  '20190317',  '20190317',  'Race',       1),
                  (6,  2,  '20190329',  '20190329',  'FP1',        1),
                  (7,  2,  '20190329',  '20190329',  'FP2',        1),
                  (8,  2,  '20190330',  '20190330',  'FP3',        1),
                  (9,  2,  '20190330',  '20190330',  'Qualifying', 1),
                  (10, 2,  '20190331',  '20190331',  'Race',       1)
          )
    AS S (Id, TrackId, StartDate, EndDate, EventName, Category)
    ON T.Id = S.Id
WHEN MATCHED THEN
    UPDATE SET
    TrackId = S.TrackId,
    StartDate = S.StartDate,
    EndDate = S.EndDate,
    EventName = S.EventName,
    Category = S.Category
WHEN NOT MATCHED THEN
    INSERT (Id, TrackId, StartDate, EndDate, EventName, Category)
    VALUES (S.Id, S.TrackId, S.StartDate, S.EndDate, S.EventName, S.Category);


SET IDENTITY_INSERT [dbo].[RaceCalendar] OFF