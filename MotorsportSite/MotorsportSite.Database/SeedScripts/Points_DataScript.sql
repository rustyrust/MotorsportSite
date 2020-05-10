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

SET IDENTITY_INSERT [dbo].[Points] ON;


MERGE INTO [dbo].[Points]AS T
    USING (
           VALUES (1,   25,  1,  'Both', 2019, NULL),
                  (2,   18,  2,  'Both', 2019, NULL),
                  (3,   15,  3,  'Both', 2019, NULL),
                  (4,   12,  4,  'Both', 2019, NULL),
                  (5,   10,  5,  'Both', 2019, NULL),
                  (6,    8,  6,  'Both', 2019, NULL),
                  (7,    6,  7,  'Both', 2019, NULL),
                  (8,    4,  8,  'Both', 2019, NULL),
                  (9,    2,  9,  'Both', 2019, NULL),
                  (10,   1,  10, 'Both', 2019, NULL),
                  (11,   0,  11, 'Both', 2019, NULL),
                  (12,   0,  12, 'Both', 2019, NULL),
                  (13,   0,  13, 'Both', 2019, NULL),
                  (14,   0,  14, 'Both', 2019, NULL),
                  (15,   0,  15, 'Both', 2019, NULL),
                  (16,   0,  16, 'Both', 2019, NULL),
                  (17,   0,  17, 'Both', 2019, NULL),
                  (18,   0,  18, 'Both', 2019, NULL),
                  (19,   0,  19, 'Both', 2019, NULL),
                  (20,   0,  20, 'Both', 2019, NULL),
                  (21,   0,  0,  'Both', 2019, NULL)
          )
    AS S (Id, Points, Position, AllicationFor, StartYear, EndYear)
    ON T.Id = S.Id
WHEN MATCHED THEN
    UPDATE SET
    Points = S.Points,
    Position = S.Position,
    AllicationFor = S.AllicationFor,
    StartYear = S.StartYear,
    EndYear = S.EndYear
WHEN NOT MATCHED THEN
    INSERT (Id, Points, Position, AllicationFor, StartYear, EndYear)
    VALUES (S.Id, S.Points, S.Position, S.AllicationFor, S.StartYear, S.EndYear);


SET IDENTITY_INSERT [dbo].[Points] OFF