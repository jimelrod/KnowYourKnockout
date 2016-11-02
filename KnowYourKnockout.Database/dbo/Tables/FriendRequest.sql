CREATE TABLE [dbo].[FriendRequest]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
    [RequesterId] INT NOT NULL, 
    [RequesteeId] INT NOT NULL, 
    [IsAccepted] BIT NOT NULL DEFAULT 0, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    [SentOn] DATETIME NOT NULL DEFAULT GETDATE(), 
    [RespondedOn] DATETIME NULL DEFAULT GETDATE(), 

	CONSTRAINT [PK_FriendRequest] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_FriendRequest_User_Requester] FOREIGN KEY ([RequesterId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_FriendRequest_User_Requestee] FOREIGN KEY ([RequesteeId]) REFERENCES [User]([Id]),
	CONSTRAINT CHK_FriendRelationship CHECK ([RequesterId] <> [RequesteeId] AND [dbo].[FriendRequestCount]([RequesterId], [RequesteeId]) = 1)
)
