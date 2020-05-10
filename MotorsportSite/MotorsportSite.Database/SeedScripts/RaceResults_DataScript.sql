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
           VALUES (1,  1, 2, 1,  0, 58, 2, 1),
                  (2,  1, 1, 2,  0, 58, 2, 0),
                  (3,  1, 5, 3,  0, 58, 2, 0),
                  (4,  1, 3, 4,  0, 58, 2, 0),
                  (5,  1, 4, 5,  0, 58, 2, 0),
                  (6,  2, 1, 1,  0, 57, 2, 0),
                  (7,  2, 2, 2,  0, 57, 2, 0),
                  (8,  2, 4, 3,  0, 57, 2, 1),
                  (9,  2, 5, 4,  0, 57, 2, 0),
                  (10, 2, 3, 5,  0, 57, 2, 0),
                  (11, 1, 6, 14, 0, 57, 2, 0),
                  (12, 1, 7, 21, 0, 9,  1, 0),
                  (13, 1, 8, 12, 0, 57, 2, 0),
                  (14, 2, 6, 8,  0, 57, 2, 0),
                  (15, 2, 7, 21, 0, 53, 2, 0),
                  (16, 2, 8, 6,  0, 57, 2, 0)

          )
    AS S (Id, TrackId, DriverId, PointsId, IsChampion, LapsCompleted, NumStops, FastestLap)
    ON T.Id = S.Id
WHEN MATCHED THEN
UPDATE SET
    TrackId = S.TrackId,
    DriverId = S.DriverId,
    PointsId = S.PointsId,
    IsChampion = S.IsChampion,
    LapsCompleted = S.LapsCompleted,
    NumStops = S.NumStops,
    FastestLap = S.FastestLap
WHEN NOT MATCHED THEN
    INSERT (Id, TrackId, DriverId, PointsId, IsChampion, LapsCompleted, NumStops, FastestLap)
    VALUES (S.Id, S.TrackId, S.DriverId, S.PointsId, S.IsChampion, S.LapsCompleted, S.NumStops, S.FastestLap);


SET IDENTITY_INSERT [dbo].[RaceResults] OFF