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

SET IDENTITY_INSERT [dbo].[Qualifying] ON;


MERGE INTO [dbo].[Qualifying] AS T
    USING (        --Austria 2020 5th
           VALUES (1,   1,  109, '1:04.198',  '1:03.096', '1:02.951', 21, 2,  4, 0),
                  (2,   2,  109, '1:04.111',  '1:03.015', '1:02.939', 19, 1,  4, 0),
                  (3,   3,  109, '1:04.554',  '1:04.206',  NULL,      13, 11, 4, 0),
                  (4,   4,  109, '1:04.500',  '1:04.041', '1:03.923', 20, 7,  4, 0),
                  (5,   5,  109, '1:04.024',  '1:04.000', '1:03.477', 23, 3,  4, 0),
                  (6,   6,  109, '1:04.661',  '1:03.746', '1:03.868', 18, 5,  4, 0),
                  (7,   7,  109, '1:04.537',  '1:03.971', '1:03.971', 18, 8,  4, 0),
                  (8,   8,  109, '1:04.606',  '1:03.819', '1:03.626', 17, 4,  4, 0),

                  --Austria 2019
                  (9,   1,  44,  '1:03.818',  '1:03.803', '1:03.262', 25, 2,  4, 0),
                  (10,  2,  44,  '1:04.084',  '1:03.863', '1:03.537', 27, 4,  4, 0),
                  (11,  3,  44,  '1:04.340',  '1:03.667',  NULL,      9,  10, 4, 0),
                  (12,  4,  44,  '1:04.138',  '1:03.378', '1:03.003', 19, 1,  4, 0),
                  (13,  5,  44,  '1:03.807',  '1:03.835', '1:03.439', 18, 3,  4, 0),
                  (14,  6,  44,  '1:04.708',  '1:04.665',  NULL,      15, 13, 4, 0),
                  (15,  7,  44,  '1:04.453',  '1:13.601',  NULL,      12, 15, 4, 0),
                  (16,  8,  44,  '1:04.361',  '1:04.211', '1:04.099', 19, 6,  4, 0)
          )
    AS S (Id, DriverId, CalId, Q1Time, Q2Time, Q3Time, Laps, Position, TireId, TrackRecord)
    ON T.Id = S.Id
WHEN MATCHED THEN
UPDATE SET
    CalId = S.CalId,
    DriverId = S.DriverId,
    Q1Time = S.Q1Time,
    Q2Time = S.Q2Time,
    Q3Time = S.Q3Time,
    Laps = S.Laps,
    Position = S.Position,
    TireId = S.TireId,
    TrackRecord = S.TrackRecord
WHEN NOT MATCHED THEN
    INSERT (Id, DriverId, CalId, Q1Time, Q2Time, Q3Time, Laps, Position, TireId, TrackRecord)
    VALUES (S.Id, S.DriverId, S.CalId, S.Q1Time, S.Q2Time, S.Q3Time, S.Laps, S.Position, S.TireId, S.TrackRecord);


SET IDENTITY_INSERT [dbo].[Qualifying] OFF