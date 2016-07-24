MERGE INTO [dbo].[User] AS Target 
USING (VALUES 
  (CONVERT(uniqueidentifier, '54b07170-425d-4827-a871-d424d677f209'), N'elrod.development@gmail.com', N'Jim', N'Elrod', 1), 
  (CONVERT(uniqueidentifier, '55a400cb-8f68-4bca-927b-9b00d752e805'), N'annamoorman@gmail.com', N'Anna', N'Moorman', 1),
  (CONVERT(uniqueidentifier, '9d0e925b-1eab-4ff3-a018-10c9fe614aef'), N'sam.elrod@gmail.com', N'Sam', N'Elrod', 1),
  (CONVERT(uniqueidentifier, 'b15d65a1-efa9-4746-8459-54e468cb57df'), N'amberluv22@gmail.com', N'Amber', N'Ferguson', 1),
  (CONVERT(uniqueidentifier, '03f27edf-bebc-4307-9e2d-8ed70dc23584'), N'sarah@gmail.com', N'Sarah', N'Garrard', 1),
  (CONVERT(uniqueidentifier, 'aab3587b-242d-447a-926b-3ab10a4c25a9'), N'gabe@gmail.com', N'Gabriel', N'Brazil', 1),
  (CONVERT(uniqueidentifier, '65025169-ac54-4c76-9be8-d8b289e2d063'), N'kim@gmail.com', N'Kim', N'Brooks', 1),
  (CONVERT(uniqueidentifier, 'f66a1c6a-a40e-4b83-8caf-0c2133afae38'), N'duane@gmail.com', N'Duane', N'Brooks', 1),
  (CONVERT(uniqueidentifier, '100a54a4-aa76-4270-a17b-49c23ef2e88e'), N'casey.strength@gmail.com', N'Casey', N'Strength', 0),
  (CONVERT(uniqueidentifier, '0f1a48ec-34d0-4548-b1d2-153537bc1084'), N'sarah.hendrix@gmail.com', N'Sarah', N'Hendrix', 0)
) 
AS Source (Id, EmailAddress, FirstName, LastName, IsActive) 
ON Target.Id = Source.Id 
-- update matched rows 
WHEN MATCHED THEN 
UPDATE SET EmailAddress = Source.EmailAddress, 
FirstName = Source.FirstName,
LastName = Source.LastName,
IsActive = Source.IsActive
-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Id, EmailAddress, FirstName, LastName, IsActive) 
VALUES (Id, EmailAddress, FirstName, LastName, IsActive) 
-- delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
DELETE;