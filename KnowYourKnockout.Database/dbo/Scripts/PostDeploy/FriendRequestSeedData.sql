MERGE INTO [dbo].[FriendRequest] AS Target 
USING (VALUES 
  (CONVERT(uniqueidentifier, '315a068d-f0f6-44ba-a2a8-98d9c755b463'), CONVERT(uniqueidentifier, '54b07170-425d-4827-a871-d424d677f209'), CONVERT(uniqueidentifier, '55a400cb-8f68-4bca-927b-9b00d752e805'), 1, 1), 
  (CONVERT(uniqueidentifier, 'be3d9a18-e780-40d4-9d26-2044117994d6'), CONVERT(uniqueidentifier, '9d0e925b-1eab-4ff3-a018-10c9fe614aef'), CONVERT(uniqueidentifier, 'b15d65a1-efa9-4746-8459-54e468cb57df'), 1, 1),
  (CONVERT(uniqueidentifier, 'de70d025-e94c-493a-938d-8029187140c9'), CONVERT(uniqueidentifier, '03f27edf-bebc-4307-9e2d-8ed70dc23584'), CONVERT(uniqueidentifier, 'aab3587b-242d-447a-926b-3ab10a4c25a9'), 0, 1),
  (CONVERT(uniqueidentifier, '317988ed-22f5-4339-83db-b9b80195b31a'), CONVERT(uniqueidentifier, '65025169-ac54-4c76-9be8-d8b289e2d063'), CONVERT(uniqueidentifier, 'f66a1c6a-a40e-4b83-8caf-0c2133afae38'), 0, 0)
) 
AS Source (Id, RequesterId, RequesteeId, IsAccepted, IsActive) 
ON Target.Id = Source.Id 
-- update matched rows 
WHEN MATCHED THEN 
UPDATE SET RequesterId = Source.RequesterId, 
           RequesteeId = Source.RequesteeId,
           IsAccepted = Source.IsAccepted,
		   IsActive = Source.IsActive
-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Id, RequesterId, RequesteeId, IsAccepted, IsActive)
VALUES (Id, RequesterId, RequesteeId, IsAccepted, IsActive)
-- delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
DELETE;