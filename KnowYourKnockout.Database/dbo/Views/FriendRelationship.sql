CREATE VIEW [dbo].[FriendRelationship] 
AS 
  SELECT [requesterid] AS [User1Id], 
         [requesteeid] AS [User2Id] 
  FROM   [dbo].[friendrequest] 
  WHERE  [isactive] = 1 
         AND [isaccepted] = 1 