CREATE VIEW [dbo].[FriendRelationship] 
AS 
  SELECT [RequesterId] AS [User1Id], 
         [RequesteeId] AS [User2Id] 
  FROM   [dbo].[FriendRequest] 
  WHERE  [IsActive] = 1 
         AND [IsAccepted] = 1 