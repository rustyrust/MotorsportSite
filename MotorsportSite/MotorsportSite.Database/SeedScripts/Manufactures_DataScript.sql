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
SET IDENTITY_INSERT [dbo].[Manufactures] ON;


MERGE INTO [dbo].[Manufactures]AS T
    USING (
           VALUES (1,  'Renault',  '19900101',  NULL),
                  (2,  'Mercedes', '19900101',  NULL),
                  (3,  'Ferrari',  '19900101',  NULL),
                  (4,  'Honda',    '19900101',  NULL)
          )
    AS S (Id, [Name], EntryDate, LeaveDate)
    ON T.Id = S.Id
WHEN MATCHED THEN
    UPDATE SET
    EntryDate = S.EntryDate,
    LeaveDate = S.LeaveDate,
    [Name] = S.[Name]
WHEN NOT MATCHED THEN
    INSERT (Id, [Name], EntryDate, LeaveDate)
    VALUES (S.Id, S.[Name], S.EntryDate, S.LeaveDate);


SET IDENTITY_INSERT [dbo].[Manufactures] OFF