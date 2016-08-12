MERGE INTO [dbo].[Question] AS TARGET
USING (VALUES 
  (CONVERT(uniqueidentifier, 'a59b2254-d424-4184-94e6-eb9ad72d3926'), CONVERT(uniqueidentifier, '9D0E925B-1EAB-4FF3-A018-10C9FE614AEF'), CONVERT(uniqueidentifier, 'B15D65A1-EFA9-4746-8459-54E468CB57DF'), 'Question text1'),
  (CONVERT(uniqueidentifier, '1752bd6d-09d7-498c-b439-59afb852ff0e'), CONVERT(uniqueidentifier, '54B07170-425D-4827-A871-D424D677F209'), CONVERT(uniqueidentifier, '55A400CB-8F68-4BCA-927B-9B00D752E805'), 'Question text2')
) 
AS Source (Id, AskerId, ResponderId, QuestionText)
ON Target.Id = Source.Id 
-- update matched rows 
WHEN MATCHED THEN 
UPDATE SET AskerId = Source.AskerId, 
ResponderId = Source.ResponderId,
QuestionText = Source.QuestionText
-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Id, AskerId, ResponderId, QuestionText)
VALUES (Id, AskerId, ResponderId, QuestionText)
-- delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
DELETE;