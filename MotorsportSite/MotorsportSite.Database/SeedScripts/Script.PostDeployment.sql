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

:r .\TeamPrinciple_DataScript.sql
:r .\Manufactures_DataScript.sql
:r .\Teams_DataScript.sql
:r .\TeamsPowerUnit_DataScript.sql
:r .\Drivers_DataScript.sql
:r .\Points_DataScript.sql
:r .\RaceTracks_DataScript.sql
:r .\RaceResults_DataScript.sql
:r .\RaceCalendar_DataScript.sql
:r .\DriversTeamMovement_DataScript.sql
:r .\Tires_DataScript.sql
:r .\Qualifyings_DataScript.sql
:r .\StartingGrid_DataScript.sql
