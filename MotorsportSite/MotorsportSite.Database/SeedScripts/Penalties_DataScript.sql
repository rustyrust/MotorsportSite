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

SET IDENTITY_INSERT [dbo].[Penalties] ON;


MERGE INTO [dbo].[Penalties] AS T
    USING ( 
           VALUES (1, 'Fine'),
                  (2, 'Grid Penalty'),
                  (3, 'Time Penalty')
          )
    AS S (Id, [Name])
    ON T.Id = S.Id
WHEN MATCHED THEN
UPDATE SET
    [Name] = S.[Name]
WHEN NOT MATCHED THEN
    INSERT (Id, [Name])
    VALUES (S.Id, S.[Name]);


SET IDENTITY_INSERT [dbo].[Penalties] OFF