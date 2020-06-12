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
           VALUES (1,  5,  2, 1,  0, 58, 2, 1, 20, 5),
                  (2,  5,  1, 2,  0, 58, 2, 0, 4 , 6),
                  (3,  5,  5, 3,  0, 58, 2, 0, 2 , 9),
                  (4,  5,  3, 4,  0, 58, 2, 0, 0 , 12),
                  (5,  5,  4, 5,  0, 58, 2, 0, 0 , 14),
                  (6,  10, 1, 1,  0, 57, 2, 0, 22, 5),
                  (7,  10, 2, 2,  0, 57, 2, 0, 0 , 3),
                  (8,  10, 4, 3,  0, 57, 2, 1, 0 , 6),
                  (9,  10, 5, 4,  0, 57, 2, 0, 2 , 9),
                  (10, 10, 3, 5,  0, 57, 2, 0, 0 , 12),
                  (11, 5,  6, 14, 0, 57, 2, 0, 0 , 5),
                  (12, 5,  7, 21, 0, 9,  1, 0, 0 , 3),
                  (13, 5,  8, 12, 0, 57, 2, 0, 0 , 15),
                  (14, 10, 6, 8,  0, 57, 2, 0, 0 , 9),
                  (15, 10, 7, 21, 0, 53, 2, 0, 0 , 8),
                  (16, 10, 8, 6,  0, 57, 2, 0, 0 , 4),

                  (17, 15, 1, 1,  0, 56, 2, 0, 16, 4),
                  (18, 15, 2, 2,  0, 56, 2, 0, 6,  5),
                  (19, 15, 3, 3,  0, 56, 2, 0, 2,  2),
                  (20, 15, 4, 5,  0, 56, 2, 0, 0,  4),
                  (21, 15, 5, 4,  0, 56, 2, 0, 0,  7),
                  (22, 15, 6, 10, 0, 55, 3, 0, 0,  8),
                  (23, 15, 7, 14, 0, 55, 2, 0, 0,  2),
                  (24, 15, 8, 21, 0, 50, 2, 0, 0,  2),

                  (25, 20, 1, 2,  0, 51, 3, 0, 12, 2),
                  (26, 20, 2, 1,  0, 51, 3, 0, 14, 4),
                  (27, 20, 3, 3,  0, 51, 3, 0, 2,  2),
                  (28, 20, 4, 5,  0, 51, 3, 0, 0,  4),
                  (29, 20, 5, 4,  0, 51, 3, 0, 0,  7),
                  (30, 20, 6, 11, 0, 50, 3, 0, 0,  8),
                  (31, 20, 7, 7,  0, 51, 3, 0, 0,  2),
                  (32, 20, 8, 8,  0, 51, 3, 0, 0,  2),

                  (33, 25, 1, 1,  0, 66, 2, 0, 20, 2),
                  (34, 25, 2, 2,  0, 66, 2, 0, 14, 4),
                  (35, 25, 3, 4,  0, 66, 2, 0, 2,  2),
                  (36, 25, 4, 5,  0, 66, 2, 0, 0,  4),
                  (37, 25, 5, 3,  0, 66, 2, 0, 0,  7),
                  (38, 25, 6, 11, 0, 66, 2, 0, 0,  8),
                  (39, 25, 7, 8,  0, 66, 2, 0, 0,  2),
                  (40, 25, 8, 21, 0, 44, 2, 0, 0,  2),

                  (41, 30, 1, 1,  0, 78, 2, 0, 70, 2),
                  (42, 30, 2, 3,  0, 78, 2, 0, 0,  2),
                  (43, 30, 3, 2,  0, 66, 2, 0, 8,  2),
                  (44, 30, 4, 21, 0, 16, 2, 0, 0,  2),
                  (45, 30, 5, 4,  0, 78, 2, 0, 0,  3),
                  (46, 30, 6, 8,  0, 78, 2, 0, 0,  4),
                  (47, 30, 7, 6,  0, 78, 2, 0, 0,  2),
                  (48, 30, 8, 11, 0, 78, 2, 0, 0,  2)

          )
    AS S (Id, CalId, DriverId, PointsId, IsChampion, LapsCompleted, NumStops, FastestLap, LapsLead, Overtakes)
    ON T.Id = S.Id
WHEN MATCHED THEN
UPDATE SET
    CalId = S.CalId,
    DriverId = S.DriverId,
    PointsId = S.PointsId,
    IsChampion = S.IsChampion,
    LapsCompleted = S.LapsCompleted,
    NumStops = S.NumStops,
    FastestLap = S.FastestLap,
    LapsLead = S.LapsLead,
    Overtakes = S.Overtakes
WHEN NOT MATCHED THEN
    INSERT (Id, CalId, DriverId, PointsId, IsChampion, LapsCompleted, NumStops, FastestLap, LapsLead, Overtakes)
    VALUES (S.Id, S.CalId, S.DriverId, S.PointsId, S.IsChampion, S.LapsCompleted, S.NumStops, S.FastestLap, S.LapsLead, S.Overtakes);


SET IDENTITY_INSERT [dbo].[RaceResults] OFF