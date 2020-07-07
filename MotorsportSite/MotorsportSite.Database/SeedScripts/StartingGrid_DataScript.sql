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

SET IDENTITY_INSERT [dbo].[StartingGrid] ON;


MERGE INTO [dbo].[StartingGrid] AS T
    USING (        --2020 Austria 5th
           VALUES (1,  1,  109, 5, 1, 0, 'received a three-place grid penalty for failing to slow for yellow flags during qualifying.'),
                  (2,  2,  109, 1, 1, 0, NULL),
                  (3,  3,  109, 11,1, 0, NULL),
                  (4,  4,  109, 7, 1, 0, NULL),
                  (5,  5,  109, 2, 1, 0, NULL),
                  (6,  6,  109, 4, 1, 0, NULL),
                  (7,  7,  109, 8, 1, 0, NULL),
                  (8,  8,  109, 3, 1, 0, NULL),

                  --2019 Auustria
                  (9,  1,  44,  4,  1, 0, 'received a three-place grid penalty for impeding Kimi Räikkönen during qualifying. However, because of the way the penalties were applied, Hamilton dropped two places instead of three and he would start fourth.'),
                  (10, 2,  44,  3,  1, 0, NULL),
                  (11, 3,  44,  9,  1, 0, NULL),
                  (12, 4,  44,  1,  1, 0, NULL),
                  (13, 5,  44,  2,  1, 0, NULL),
                  (14, 6,  44,  18, 1, 0, 'required to start from the back of the grid for exceeding their quotas for power unit components'),
                  (15, 7,  44,  19, 1, 0, 'required to start from the back of the grid for exceeding their quotas for power unit components'),
                  (16, 8,  44,  5,  1, 0, NULL)

          )
    AS S (Id, DriverId, CalId, Position, TireId, PitStart, Discription)
    ON T.Id = S.Id
WHEN MATCHED THEN
UPDATE SET
    CalId = S.CalId,
    DriverId = S.DriverId,
    Position = S.Position,
    TireId = S.TireId,
    PitStart = S.PitStart,
    Discription = S.Discription
WHEN NOT MATCHED THEN
    INSERT (Id, DriverId, CalId, Position, TireId, PitStart, Discription)
    VALUES (S.Id, S.DriverId, S.CalId, S.Position, S.TireId, S.PitStart, S.Discription);


SET IDENTITY_INSERT [dbo].[StartingGrid] OFF