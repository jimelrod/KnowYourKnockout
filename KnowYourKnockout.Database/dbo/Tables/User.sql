﻿CREATE TABLE [dbo].[User]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [EmailAddress] NVARCHAR(50) NOT NULL UNIQUE, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL,
	[IsActive] BIT NOT NULL DEFAULT 0,
    [JoinedOn] DATETIME NOT NULL DEFAULT GETDATE()
)
