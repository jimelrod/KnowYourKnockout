MERGE INTO [dbo].[QuestionTag] AS TARGET
USING (VALUES 
  (CONVERT(uniqueidentifier, 'de1016f1-6049-4eb1-891e-c1100bece5d5'), CONVERT(uniqueidentifier, 'a59b2254-d424-4184-94e6-eb9ad72d3926'), CONVERT(uniqueidentifier, '80414055-89CD-4C80-874E-1284D45A1732')),
  (CONVERT(uniqueidentifier, '475f0e09-b9fa-42c1-ac0a-b7878764c715'), CONVERT(uniqueidentifier, 'a59b2254-d424-4184-94e6-eb9ad72d3926'), CONVERT(uniqueidentifier, 'F8663CBD-1754-4D24-9862-890F6AA33D10')),
  (CONVERT(uniqueidentifier, 'bc82f54f-5cf8-4bb1-96b4-58a51df48438'), CONVERT(uniqueidentifier, 'a59b2254-d424-4184-94e6-eb9ad72d3926'), CONVERT(uniqueidentifier, '9B3C503D-3601-4272-8EA9-8FC7423BABF3')),
  (CONVERT(uniqueidentifier, '3ba56ae3-fc93-4c85-a1ec-e732c7413966'), CONVERT(uniqueidentifier, 'a59b2254-d424-4184-94e6-eb9ad72d3926'), CONVERT(uniqueidentifier, '930EB6AC-AAF9-4E11-B765-936C9DE473A4')),
  (CONVERT(uniqueidentifier, '53875d28-9e15-4d55-b6eb-275e750015d4'), CONVERT(uniqueidentifier, '1752bd6d-09d7-498c-b439-59afb852ff0e'), CONVERT(uniqueidentifier, '930EB6AC-AAF9-4E11-B765-936C9DE473A4')),
  (CONVERT(uniqueidentifier, 'b056fb4f-f501-4004-b41c-bdb66c44d183'), CONVERT(uniqueidentifier, '1752bd6d-09d7-498c-b439-59afb852ff0e'), CONVERT(uniqueidentifier, '1437681B-3FC3-4502-9259-C2EBFA0E7596'))
) 
AS Source (Id, QuestionId, TagId)
ON Target.Id = Source.Id 
-- update matched rows 
WHEN MATCHED THEN 
UPDATE SET QuestionId = Source.QuestionId, 
TagId = Source.TagId
-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Id, QuestionId, TagId)
VALUES (Id, QuestionId, TagId)
-- delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
DELETE;