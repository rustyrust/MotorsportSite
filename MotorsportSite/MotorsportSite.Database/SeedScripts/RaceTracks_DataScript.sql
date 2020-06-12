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
           VALUES (1,  'Melbourne',           'Austraila',     'Albert Park',                         5.303, 58, 16, 1, 0, 0),
                  (2,  'Sakhir',              'Bahrain',       'Bahrain International Circuit',       5.412, 57, 15, 1, 0, 0),
                  (3,  'Shanghai',            'China',         'Shanghai International Circuit',      5.451, 57, 16, 1, 0, 0),
                  (4,  'Baku',                'Azerbaijan',    'Baku City Circuit',                   6.003, 51, 20, 1, 1, 0),
                  (5,  'Catalunya',           'Spain',         'Circuit de Barcelona-Catalunya',      4.655, 66, 16, 1, 0, 0),
                  (6,  'Monaco',              'Monaco',        'Circuit de Monaco',                   3.337, 78, 19, 1, 1, 0),
                  (7,  'Montreal',            'Canada',        'Circuit Gilles Villeneuve',           4.361, 70, 14, 1, 0, 0),
                  (8,  'Le Castellet',        'France',        'Circuit Paul Ricard',                 5.842, 53, 15, 1, 0, 0),
                  (9,  'Spielberg',           'Austria',       'Red Bull Ring',                       4.318, 71, 10, 1, 0, 0),
                  (10, 'Silverstone',         'Great Britain', 'Silverstone Circuit',                 5.891, 52, 18, 1, 0, 0),
                  (11, 'Hockenheim',          'Germany',       'Hockenheimring',                      4.574, 67, 17, 1, 0, 0),
                  (12, 'Budapest',            'Hungary',       'Hungaroring',                         4.381, 70, 14, 1, 0, 0),
                  (13, 'Stavelot',            'Belgium',       'Circuit de Spa-Francorchamps',        7.004, 44, 19, 1, 0, 0),
                  (14, 'Monza',               'Italy',         'Autodromo Nazionale Monza',           5.793, 53, 11, 1, 0, 0),
                  (15, 'Singapore',           'Singapore',     'Marina Bay Street Circuit',           4.381, 70, 14, 1, 1, 0),
                  (16, 'Sochi',               'Russia',        'Sochi Autodrom',                      5.848, 53, 18, 1, 1, 0),
                  (17, 'Suzuka',              'Japan',         'Suzuka International Racing Course',  5.807, 53, 18, 1, 0, 0),
                  (18, 'Mexico City',         'Mexico',        'Autodromo Hermanos Rodriguez',        4.381, 71, 17, 1, 0, 0),
                  (19, 'Austin',              'USA',           'Circuit of The Americas',             5.513, 56, 20, 0, 0, 0),
                  (20, 'Sao Paulo',           'Brazil',        'Autodromo Jose Carlos Pace',          4.309, 71, 15, 1, 0, 0),
                  (21, 'Yas Marina',          'Abu Dhabi',     'Yas Marina Circuit',                  5.554, 55, 21, 1, 0, 0)

          )
    AS S (Id, [Location], Country, TrackName, TrackLength, Laps, NumberOfCorners, IsClockwise, IsStreetCircuit, IsDeleted)
    ON T.Id = S.Id
WHEN MATCHED THEN
UPDATE SET
    [Location] =      S.[Location],
    Country =         S.Country,
    TrackName =       S.TrackName,
    TrackLength =     S.TrackLength,
    Laps =            S.Laps,
    NumberOfCorners = S.NumberOfCorners,
    IsClockwise =     S.IsClockwise,
    IsStreetCircuit = S.IsStreetCircuit,
    IsDeleted =       S.IsDeleted
WHEN NOT MATCHED THEN
    INSERT (Id, [Location], Country, TrackName, TrackLength, Laps, NumberOfCorners, IsClockwise, IsStreetCircuit, IsDeleted)
    VALUES (S.Id, S.[Location], S.Country, S.TrackName, S.TrackLength, S.Laps, S.NumberOfCorners, S.IsClockwise, S.IsStreetCircuit, S.IsDeleted);


SET IDENTITY_INSERT [dbo].[RaceTracks] OFF