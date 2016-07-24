CREATE FUNCTION [dbo].[FriendRequestCount]
(
	@user1 UNIQUEIDENTIFIER,
	@user2 UNIQUEIDENTIFIER
)
RETURNS INT
AS
BEGIN
	DECLARE @count smallint;

	SELECT @count = COUNT(*)
	FROM [dbo].[FriendRequest]
	WHERE ([RequesterId] = @user1 and [RequesteeId] = @user2)
		OR ([RequesteeId] = @user1 and [RequesterId] = @user2);

	RETURN @count
END
