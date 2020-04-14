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
           VALUES (1,  'Toto',     'Wolff',    'Austria',  '19720112',  '20130101', NULL),
                  (2,  'Andreas',  'Seidl',    'German',   '19760106',  '20190110', NULL),
                  (3,  'Eric',     'Boullier', 'French',   '19731109',  '20140101', '20180704')
          )
    AS S (Id, FirstName, LastName, Nationality, DOB, EntryDate, LeaveDate)
    ON T.Id = S.Id
WHEN NOT MATCHED THEN
    INSERT (Id, FirstName, LastName, Nationality, DOB, EntryDate, LeaveDate)
    VALUES (S.Id, S.FirstName, S.LastName, S.Nationality, S.DOB, S.EntryDate, S.LeaveDate);


SET IDENTITY_INSERT [dbo].[TeamPrinciple] OFF
