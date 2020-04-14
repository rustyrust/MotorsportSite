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
--SET IDENTITY_INSERT [dbo].[TeamPrinciple] ON;

--INSERT INTO [dbo].[TeamPrinciple] (Id, FirstName, LastName, Nationality, DOB, EntryDate, LeaveDate)
--VALUES (1,'Toto', 'Wolff', 'Austria', 12/01/1972, 01/01/2013),
--       (2, 'Andreas', 'Seidl', 'German', 06/01/1976, 10/01/2019),
--       (3, 'Eric', 'Boullier', 'French', 09/11/1973, 01/01/2014, 04/07/2018)

--SET IDENTITY_INSERT [dbo].[TeamPrinciple] OFF

--SELECT *
--FROM dbo.Teams