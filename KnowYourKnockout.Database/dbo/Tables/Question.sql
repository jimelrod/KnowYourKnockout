﻿CREATE TABLE [dbo].[Question]
(
	[Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [AskerId] UNIQUEIDENTIFIER NOT NULL,
    [ResponderId] UNIQUEIDENTIFIER NOT NULL,
    [QuestionText] NVARCHAR(MAX) NOT NULL, 
	[AnswerText] NVARCHAR(MAX), 
    [IsQuestionPublic] BIT NOT NULL DEFAULT 0,
	[IsAnswerPublished] BIT NOT NULL DEFAULT 0,
	[AskedOn] DATETIME NOT NULL DEFAULT GETDATE(),
	[AnsweredOn] DATETIME NULL DEFAULT GETDATE(),

	CONSTRAINT [PK_Question] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Question_User_Asker] FOREIGN KEY ([AskerId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_Question_User_Responder] FOREIGN KEY ([ResponderId]) REFERENCES [User]([Id])
)
