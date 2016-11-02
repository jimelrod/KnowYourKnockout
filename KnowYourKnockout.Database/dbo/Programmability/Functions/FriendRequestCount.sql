CREATE FUNCTION [dbo].[FriendRequestCount]
(
	@user1 INT,
	@user2 INT
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
