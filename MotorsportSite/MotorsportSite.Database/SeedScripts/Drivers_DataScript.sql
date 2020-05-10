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

SET IDENTITY_INSERT [dbo].[Drivers] ON;


MERGE INTO [dbo].[Drivers] AS T
    USING (
           VALUES (1,  'Lewis',     'Hamilton',    'HAM', 44,  '19850107', 'Stevenage',   'England',      1),
                  (2,  'Valtteri',  'Botas',       'BOT', 77,  '19890828', 'Nastola',     'Finland',      1),
                  (3,  'Sebastian', 'Vettel',      'VET', 5,   '19870703', 'Heppenheim',  'German',       1),
                  (4,  'Charles',   'Leclerc',     'LEC', 16,  '19971016', 'Monaco',      'Italy',        1),
                  (5,  'Max',       'Verstappen',  'VER', 33,  '19970930', 'Belgium',     'Netherlands',  1),
                  (6,  'Alexander', 'Albon',       'ALB', 23,  '19960323', 'London',      'Thailand',     1),
                  (7,  'Carlos',    'Sainz',       'SAI', 55,  '19940901', 'Madrid',      'Spain',        1),
                  (8,  'Lando',     'Norris',      'NOR', 4,   '19991113', 'Bristol',     'England',      1)
          )
    AS S (Id, FirstName, LastName, ShortName, DriverNumber, DOB, PlaceOfBirth, Country, CatagoryId)
    ON T.Id = S.Id
WHEN MATCHED THEN
UPDATE SET
    FirstName = S.FirstName,
    LastName = S.LastName,
    ShortName = S.ShortName,
    DriverNumber = S.DriverNumber,
    DOB = S.DOB,
    PlaceOfBirth = S.PlaceOfBirth,
    Country = S.Country,
    CatagoryId = S.CatagoryId
WHEN NOT MATCHED THEN
    INSERT (Id, FirstName, LastName, ShortName, DriverNumber, DOB, PlaceOfBirth, Country, CatagoryId)
    VALUES (S.Id, S.FirstName, S.LastName, S.ShortName, S.DriverNumber, S.DOB, S.PlaceOfBirth, S.Country, S.CatagoryId);


SET IDENTITY_INSERT [dbo].[Drivers] OFF