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

SET IDENTITY_INSERT [dbo].[Tires] ON;


MERGE INTO [dbo].[Tires] AS T
    USING (
           VALUES (1, 'C1',           'Hard',          'White',  13, 'Dry', 'Slick',   5, 1, 'C1 stands for Compound 1, and it’s the hardest tyre in the 2020 Pirelli range, sitting just below the 2019 hard in terms of compounding. It’s designed for circuits that put the highest energy loadings through the tyres, which will typically feat.'),
                  (2, 'C2',           'Medium',        'Yellow', 13, 'Dry', 'Slick',   4, 2, 'C2 means Compound 2, effectively last year''s medium tyre. A versatile compound, but sitting at the harder part of the spectrum, it comes into its own on circuits that tend towards high speeds, temperatures, and energy loadings. This tyre has demonstrated an ample working range and adaptability to a wide variety of different circuits.'),
                  (3, 'C3',           'Soft',          'Red',    13, 'Dry', 'Slick',   3, 3, 'This tyre is equivalent to the soft that was nominated in all but four of the races last year. It strikes a very good balance between performance and durability, with the accent on performance. It’s a very adaptable tyre that can be used as the softest compound at a high-severity track as well as the hardest compound at a low-severity track or street circuit.'),
                  (4, 'C4',           'Ultrasoft',     'Red',    13, 'Dry', 'Slick',   2, 4, 'This is closest to the 2019 ultrasoft and it works well on tight and twisty circuits. It has a rapid warm-up and huge peak performance, but the other side of this is its relatively limited overall life.'),
                  (5, 'C5',           'Hypersoft',     'Red',    13, 'Dry', 'Slick',   1, 5, 'The softest 2020 compound is the heir to the universally-popular hypersoft: the fastest compound that Pirelli has ever made. This tyre is suitable for all circuits that demand high levels of mechanical grip, but the trade-off for this extra speed and adhesion is a considerably shorter lifespan than the other tyres in the range. Getting the most out of it will be a key to race strategy.'),
                  (6, 'INTERMEDIATE', 'Intermediates', 'Green',  13, 'Wet', 'Treaded', NULL, NULL, 'The intermediates are the most versatile of the rain tyres. They can be used on a wet track with no standing water, as well as a drying surface. This tyre evacuates 30 litres of water per second per tyre at 300kph. There’s a new compound that is designed to expand the working range, guaranteeing a proper crossover both with the slicks and the full wets.'),
                  (7, 'CINTURATO',    'Full Wets',     'Blue',   13, 'Wet', 'Treaded', NULL, NULL, 'The full wet tyres are the most effective solution for heavy rain. These tyres can evacuate 85 litres of water per second per tyre at 300kph. There’s a new profile designed to increase resistance to aquaplaning, which will give the tyre more grip in heavy rain. The diameter of the full wet tyre is 10mm wider than the slick tyre.')

          )
    AS S (Id, CompoundType, TireName, TireColour, TireSize, Thread, DrivingCondition, GripLevel, DurabilityLevel, [Description])
    ON T.Id = S.Id
WHEN MATCHED THEN
UPDATE SET
    CompoundType = S.CompoundType,
    TireName = S.TireName,
    TireColour = S.TireColour,
    TireSize = S.TireSize,
    Thread = S.Thread,
    DrivingCondition = S.DrivingCondition,
    GripLevel = S. GripLevel,
    DurabilityLevel = S.DurabilityLevel,
    [Description] = S.[Description]
WHEN NOT MATCHED THEN
    INSERT (Id, CompoundType, TireName, TireColour, TireSize, Thread, DrivingCondition, GripLevel, DurabilityLevel, [Description])
    VALUES (S.Id, S.CompoundType, S.TireName, S.TireColour, S.TireSize, S.Thread, S.DrivingCondition, S.GripLevel, S.DurabilityLevel, S.[Description]);


SET IDENTITY_INSERT [dbo].[Tires] OFF