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

SET IDENTITY_INSERT [dbo].[RaceResults] ON;


MERGE INTO [dbo].[RaceResults] AS T
    USING (
           VALUES (1,  5,  2, 1,  0, 58, 2, 1),
                  (2,  5,  1, 2,  0, 58, 2, 0),
                  (3,  5,  5, 3,  0, 58, 2, 0),
                  (4,  5,  3, 4,  0, 58, 2, 0),
                  (5,  5,  4, 5,  0, 58, 2, 0),
                  (6,  10, 1, 1,  0, 57, 2, 0),
                  (7,  10, 2, 2,  0, 57, 2, 0),
                  (8,  10, 4, 3,  0, 57, 2, 1),
                  (9,  10, 5, 4,  0, 57, 2, 0),
                  (10, 10, 3, 5,  0, 57, 2, 0),
                  (11, 5,  6, 14, 0, 57, 2, 0),
                  (12, 5,  7, 21, 0, 9,  1, 0),
                  (13, 5,  8, 12, 0, 57, 2, 0),
                  (14, 10, 6, 8,  0, 57, 2, 0),
                  (15, 10, 7, 21, 0, 53, 2, 0),
                  (16, 10, 8, 6,  0, 57, 2, 0)

          )
    AS S (Id, CalId, DriverId, PointsId, IsChampion, LapsCompleted, NumStops, FastestLap)
    ON T.Id = S.Id
WHEN MATCHED THEN
UPDATE SET
    CalId = S.CalId,
    DriverId = S.DriverId,
    PointsId = S.PointsId,
    IsChampion = S.IsChampion,
    LapsCompleted = S.LapsCompleted,
    NumStops = S.NumStops,
    FastestLap = S.FastestLap
WHEN NOT MATCHED THEN
    INSERT (Id, CalId, DriverId, PointsId, IsChampion, LapsCompleted, NumStops, FastestLap)
    VALUES (S.Id, S.CalId, S.DriverId, S.PointsId, S.IsChampion, S.LapsCompleted, S.NumStops, S.FastestLap);


SET IDENTITY_INSERT [dbo].[RaceResults] OFF