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
           VALUES (1,  2,  'Mclaren',  '19800101',  NULL, 'Pappia'),
                  (2,  1,  'Mercedes', '19750101',  NULL, 'Silver')
          )
    AS S (Id, TeamPrincipleId, TeamName, EntryDate, LeaveDate, Livery)
    ON T.Id = S.Id
WHEN MATCHED THEN
    UPDATE SET
    EntryDate = S.EntryDate,
    LeaveDate = S.LeaveDate,
    TeamPrincipleId = S.TeamPrincipleId,
    TeamName = S.TeamName,
    Livery = S.Livery
WHEN NOT MATCHED THEN
    INSERT (Id, TeamPrincipleId, TeamName, EntryDate, LeaveDate, Livery)
    VALUES (S.Id, S.TeamPrincipleId, S.TeamName, S.EntryDate, S.LeaveDate, S.Livery);


SET IDENTITY_INSERT [dbo].[Teams] OFF