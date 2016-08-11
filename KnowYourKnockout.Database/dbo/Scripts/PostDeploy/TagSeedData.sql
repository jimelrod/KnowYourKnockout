MERGE INTO [dbo].[Tag] AS Target 
USING (VALUES 
  (CONVERT(uniqueidentifier, '9b3c503d-3601-4272-8ea9-8fc7423babf3'), N'Politics'), 
  (CONVERT(uniqueidentifier, '80414055-89cd-4c80-874e-1284d45a1732'), N'Religion'), 
  (CONVERT(uniqueidentifier, '1437681b-3fc3-4502-9259-c2ebfa0e7596'), N'Education'),
  (CONVERT(uniqueidentifier, 'f8663cbd-1754-4d24-9862-890f6aa33d10'), N'Family'),
  (CONVERT(uniqueidentifier, '930eb6ac-aaf9-4e11-b765-936c9de473a4'), N'Vices')
) 
AS Source (Id, Name) 
ON Target.Id = Source.Id 
-- update matched rows 
WHEN MATCHED THEN 
UPDATE SET Name = Source.Name 
-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Id, Name) 
VALUES (Id, Name) 
-- delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
DELETE;