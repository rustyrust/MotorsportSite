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

SET IDENTITY_INSERT [dbo].[Teams] ON;


MERGE INTO [dbo].[Teams]AS T
    USING (
           VALUES (1,  'Mclaren',            '19800101',  NULL, 'Pappia',   '#FF8700'),
                  (2,  'Mercedes',           '19750101',  NULL, 'Silver',   '#00D2BE'),
                  (3,  'Ferrari',            '19750101',  NULL, 'Red',      '#DC0000'),
                  (4,  'Red Bull',           '19800101',  NULL, 'Purple',   '#000066'),
                  (5,  'Renault',            '19750101',  NULL, 'Yellow',   '#FFF500'),
                  (6,  'AlphaTauri',         '19750101',  NULL, 'White',    '#000066'),
                  (7,  'Raceing Point',      '19750101',  NULL, 'Pink',     '#F596C8'),
                  (8,  'Alfa Romeo Racing',  '19800101',  NULL, 'Dark Red', '#960000'),
                  (9,  'Williams',           '19750101',  NULL, 'White',    '#00ccff'),
                  (10, 'Hass F1 Team',       '19750101',  NULL, 'Black',    '#787878')
          )
    AS S (Id, TeamName, EntryDate, LeaveDate, PrimaryColourName, PrimaryColour)
    ON T.Id = S.Id
WHEN MATCHED THEN
    UPDATE SET
    EntryDate = S.EntryDate,
    LeaveDate = S.LeaveDate,
    TeamName = S.TeamName,
    PrimaryColourName = S.PrimaryColourName,
    PrimaryColour = S.PrimaryColour
WHEN NOT MATCHED THEN
    INSERT (Id, TeamName, EntryDate, LeaveDate, PrimaryColourName, PrimaryColour)
    VALUES (S.Id, S.TeamName, S.EntryDate, S.LeaveDate, S.PrimaryColourName, S.PrimaryColour);


SET IDENTITY_INSERT [dbo].[Teams] OFF