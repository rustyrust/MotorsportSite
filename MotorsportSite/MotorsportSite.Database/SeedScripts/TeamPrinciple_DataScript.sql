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
SET IDENTITY_INSERT [dbo].[TeamPrinciple] ON;


MERGE INTO [dbo].[TeamPrinciple] AS T
    USING (
           VALUES (1,  'Toto',     'Wolff',    'Austria',  '19720112'),
                  (2,  'Andreas',  'Seidl',    'German',   '19760106'),
                  (3,  'Eric',     'Boullier', 'French',   '19731109')
          )
    AS S (Id, FirstName, LastName, Nationality, DOB)
    ON T.Id = S.Id
WHEN MATCHED THEN
UPDATE SET
    EntryDate = S.EntryDate,
    LeaveDate = S.LeaveDate
WHEN NOT MATCHED THEN
    INSERT (Id, FirstName, LastName, Nationality, DOB)
    VALUES (S.Id, S.FirstName, S.LastName, S.Nationality, S.DOB);


SET IDENTITY_INSERT [dbo].[TeamPrinciple] OFF
