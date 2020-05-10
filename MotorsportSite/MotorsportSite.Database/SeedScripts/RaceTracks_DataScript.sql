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

SET IDENTITY_INSERT [dbo].[RaceTracks] ON;


MERGE INTO [dbo].[RaceTracks] AS T
    USING (
           VALUES (1, 'Melbourne', 'Austraila', 'Albert Park',                    5.303, 58, 16, 1, 0),
                  (2, 'Sakhir',    'Bahrain',   'Bahrain International Circuit',  5.412, 57, 15, 1, 0),
                  (3, 'Shanghai',  'China',     'Shanghai International Circuit', 5.451, 57, 16, 1, 0)
          )
    AS S (Id, [Location], Country, TrackName, TrackLength, Laps, NumberOfCorners, IsClockwise, IsDeleted)
    ON T.Id = S.Id
WHEN MATCHED THEN
UPDATE SET
    [Location] = S.[Location],
    Country = S.Country,
    TrackName = S.TrackName,
    TrackLength = S.TrackLength,
    Laps = S.Laps,
    NumberOfCorners = S.NumberOfCorners,
    IsClockwise = S.IsClockwise,
    IsDeleted = S.IsDeleted
WHEN NOT MATCHED THEN
    INSERT (Id, [Location], Country, TrackName, TrackLength, Laps, NumberOfCorners, IsClockwise, IsDeleted)
    VALUES (S.Id, S.[Location], S.Country, S.TrackName, S.TrackLength, S.Laps, S.NumberOfCorners, S.IsClockwise, S.IsDeleted);


SET IDENTITY_INSERT [dbo].[RaceTracks] OFF